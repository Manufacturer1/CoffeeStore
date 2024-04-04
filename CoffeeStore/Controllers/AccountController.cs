using AutoMapper;
using CoffeeStore.BuiesnessLogic.DTO;
using CoffeeStore.BuiesnessLogic.Infrastructure;
using CoffeeStore.BuiesnessLogic.Interfaces;
using CoffeeStore.Filters;
using CoffeeStore.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Provider;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace CoffeeStore.Controllers
{

    public class AccountController : Controller
    {
        private IOrderService orderService;
        private ICartService cartService;
        private IEditProductService editProductService;
        private IReservationService reservationService;
        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        public AccountController(IOrderService orderService, ICartService cartService, IEditProductService editProductService, IReservationService reservationService)
        {
            this.orderService = orderService;
            this.cartService = cartService;
            this.editProductService = editProductService;
            this.reservationService = reservationService;
        }

        [HttpGet]
        [SessionTimeout]
        [Authorize]
        public ActionResult ChangePassword()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> ChangePassword(PasswordModel model)
        {
            var user = await UserService.GetUserById(User.Identity.GetUserId());
            if (user == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var passwordHasher = new PasswordHasher();
            var passwordVerificationResult = passwordHasher.VerifyHashedPassword(user.Password, model.CurrentPassword);

            if(passwordVerificationResult == PasswordVerificationResult.Success)
            {
                var newPasswordHash = passwordHasher.HashPassword(model.Password);
                user.Password = newPasswordHash;
                OperationDetails operationDetails = await UserService.UpdateClient(user);

                if (operationDetails.Succeeded)
                {
                    ViewBag.PasswordChanged = true;
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", "Error changing password. Please try again.");
                    return View(model);
                }
            }
            else
            {
                
                ModelState.AddModelError("", "The current password is incorrect.");
                return View(model);
            }
          

        }

        [HttpGet]
        [SessionTimeout]
        [Authorize]
        public async Task<ActionResult> EditClientProfile()
        {   
            var user = await UserService.GetUserById(User.Identity.GetUserId());
            var editModel = new EditModel { UserName = user.UserName, Email = user.Email,Address=user.Address,Name = user.Name };
            return View(editModel);
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditClientProfile(EditModel model)
        {
            var user = await UserService.GetUserById(User.Identity.GetUserId());
            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                
            }
            if (ModelState.IsValid)
            {
                // Update the properties only if the model properties are not empty
                if (!string.IsNullOrEmpty(model.Email))
                {
                    user.Email = model.Email;
                }
                if (!string.IsNullOrEmpty(model.Name))
                {
                    user.Name = model.Name;
                }

                if (!string.IsNullOrEmpty(model.Address))
                {
                    user.Address = model.Address;
                }


                if (!string.IsNullOrEmpty(model.UserName))
                {
                    user.UserName = model.UserName;
                }
                if (!string.IsNullOrEmpty(model.Email))
                {

                }
                OperationDetails operationDetails = await UserService.UpdateClient(user);

                if (operationDetails.Succeeded)
                {
                    if (User.IsInRole("admin"))
                    {
                        return RedirectToAction("AdminDashboard");
                    }
                    else
                    {
                        return RedirectToAction("ClientProfile");
                    }
                }
            }
        
            return View(model);
        }




        [Authorize(Roles = "user")]
        [SessionTimeout]
        public async Task<ActionResult> ClientProfile()
        {
            
            var userDto = await UserService.GetUserById(User.Identity.GetUserId());
            var user = new UserModel { Id = userDto.Id,Email=userDto.Email,Address=userDto.Address,Name=userDto.Name,UserName = userDto.UserName };
            if(user == null) return HttpNotFound();
        
            return View(user);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult EditExistingProduct(int Id,string category)
        {
           var productDTO = cartService.GetProduct(Id,category);
            var productModel = new ProductModel { Id = productDTO.Id, 
                Category = category,Price = productDTO.Price,Name = productDTO.Name,
                PathImage = productDTO.PathImage };

            return View(productModel);
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult ViewAllProducts()
        {
            var productsDTO = cartService.RetrieveAllProducts();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductModel>()).CreateMapper();
            var products = mapper.Map<IEnumerable<ProductDTO>, List<ProductModel>>(productsDTO);
            

            return View(products);
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]    
        
        public ActionResult EditExistingProduct(ProductModel model)
        {
           
            if (ModelState.IsValid)
            {
               
                var ProductDTO = new ProductDTO
                {
                    Id = model.Id,
                    Name = model.Name,
                    Category = model.Category,
                    Price = model.Price,
                    PathImage = model.PathImage,
              
                };
                editProductService.UpdateProduct(ProductDTO);
                return RedirectToAction("AdminDashboard");
            }
           
            return View(model);
        }

        [Authorize(Roles ="admin")]
        [SessionTimeout]
        public async Task<ActionResult> AdminDashboard()
        {

            var userAdmin = await UserService.GetUserById(User.Identity.GetUserId());
            var adminModel = new UserModel
            {
                Email = userAdmin.Email,
                Name = userAdmin.Name,
                UserName = userAdmin.UserName,
                Address = userAdmin.Address
            };
            IEnumerable<UserModel> users = new List<UserModel>();
            var usersDto = await UserService.GetAllUsers();
     
            if (usersDto != null)
            {
                users = usersDto.Select(userDto =>
                {
                    var userModel = new UserModel
                    {
                        Id = userDto.Id,
                        Email = userDto.Email,
                        UserName = userDto.UserName,
                        Address = userDto.Address,
                        Name = userDto.Name,
                    };
                   
                    var orderDto = orderService.GetOrdersByUserId(userModel.Id);
               
                    

                    if (orderDto != null)
                        {
                        userModel.Orders = orderDto.Select(o => new OrderViewModel
                        {
                            Id = o.Id,
                            FirstName = o.FirstName,
                            LastName = o.LastName,
                            PhoneNumber = o.Phone,
                            Email = o.Email,
                            Address = o.StreetAddress,
                            Appartment = o.Appartment,
                            City = o.City,
                            Country = o.Country,
                            PostCode = o.PostCode,
                            BuyingTime = o.BuyingTime,
                            ApplicationUserId = o.ApplicationUserId,
                            TotalSumToPay = o.TotalSumToPay,
                            Items = o.Items
                        }).ToList();
                         
                        }
                   
                    return userModel;
                });

            }
  
            ViewBag.Users = users;  
            return View(adminModel);
        }
        [Authorize(Roles ="admin")]
        public async  Task<ActionResult> ReservationDetails(string userId)
        {
            var reservationsDTO = reservationService.GetReservationsByUserId(userId);
            var userDTO = await UserService.GetUserById(userId);
            UserModel user = new UserModel();
            if (userDTO != null)
            {
                user.Id = userDTO.Id;
                user.Address = userDTO.Address;
                user.UserName = userDTO.UserName; 
                user.Email = userDTO.Email;
                user.Name = userDTO.Name;
                
               
                if (reservationsDTO != null)
                {

                    user.Reservations = reservationsDTO.Select(r => new ReservationViewModel
                    {
                        Id = r.Id,
                        FirstName = r.FirstName,
                        LastName = r.LastName,
                        PhoneNumber = r.PhoneNumber,
                        Message = r.Message,
                        ReservationTime = r.ReservationTime,
                        ReservationDate = r.ReservationDate,
                    }).ToList();
                }
              
            }
           return View(user);
            
        }
        public ActionResult Login()
        {
            ViewBag.CurrentAction = "Login";
            return View();  
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            /*await SetInitialDataAsync();*/
            if (ModelState.IsValid)
            {
                UserDTO userDTO = new UserDTO { UserName = model.UserName,Password = model.Password };
                ClaimsIdentity claim = await UserService.Authenticate(userDTO);
                if(claim == null)
                {
                    ModelState.AddModelError("", "Incorrect login or password!");
                }
                else
                {
                    var userRole = claim.FindFirst(ClaimTypes.Role)?.Value;

                    if (userRole == "admin")
                    {
                        Session["UserId"] = "admin";
                        AuthenticationManager.SignOut();
                        AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, claim);
                        return RedirectToAction("AdminDashboard");

                    }
                    else
                    {
                        Session["UserId"] = "user";
                        AuthenticationManager.SignOut();
                        AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, claim);
                        return RedirectToAction("ClientProfile", "Account");
                    }
                }
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [AllowAnonymous]
        public ActionResult Register()
        {
            ViewBag.CurrentAction = "Register";
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
           /* await SetInitialDataAsync();*/
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO
                {
                    Email = model.Email,
                    Password = model.Password,
                    Address = model.Address,
                    Name = model.Name,
                    UserName = model.UserName,
                    Role = "user"
                };
                OperationDetails operationDetails = await UserService.Create(userDto);
                if (operationDetails.Succeeded) return RedirectToAction("Login");
                else ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }

      

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult> DeleteUser(string username)
        {
            if (username == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            
            var result = await UserService.DeleteUserByUsername(username);
            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "User deleted successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to delete user.";
            }

            return RedirectToAction("AdminDashboard");
        }
/*        private UserDTO GetAdminInfo()
        {
            return new UserDTO
            {
                Email = "mihai@gmail.com",
                UserName = "King123",
                Password = "King123",
                Name = "Application Admin",
                Address = "New York Street 34",
                Role = "admin",
            };
        }
        private async Task SetInitialDataAsync()
        {
            UserDTO adminUser = GetAdminInfo();
            await UserService.SetInitialData(adminUser, new List<string> { "user", "admin" });
        }

*/
        protected override void Dispose(bool disposing)
        {
            UserService.Dispose();
            cartService.Dispose();
            orderService.Dispose();
            editProductService.Dispose();
            reservationService.Dispose();   
            base.Dispose(disposing);
        }

    }

}