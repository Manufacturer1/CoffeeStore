using AutoMapper;
using CoffeeStore.Models;
using CoffeeStore.BuiesnessLogic.DTO;
using CoffeeStore.BuiesnessLogic.Interfaces;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using CoffeeStore.Domain.Entities;
using CoffeeStore.Filters;
using Microsoft.Owin.Security;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace CoffeeStore.Controllers
{
    [SessionTimeout]
    public class BuyController : Controller
    {
     
        private ICartService _cartService;
        private IOrderService _orderService;
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
        public BuyController(IOrderService orderService,ICartService cart_serv)
        {
            _cartService = cart_serv;
            _orderService = orderService;
     
        }
        // GET: Buy
        [HttpGet]
        public ActionResult Shop()
        {
            IEnumerable<ProductDTO> productDTOs = _cartService.GetProducts("Coffee");
            var product_mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductModel>()).CreateMapper();
            var products = product_mapper.Map<IEnumerable<ProductDTO>, List<ProductModel>>(productDTOs);

            IEnumerable<ProductDTO> mainDishDTO = _cartService.GetProducts("MainDish");
            IEnumerable<ProductDTO> drinksDTO = _cartService.GetProducts("Drink");
            IEnumerable<ProductDTO> dessertsDTO = _cartService.GetProducts("Dessert");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductModel>()).CreateMapper();
            var mainDish = mapper.Map<IEnumerable<ProductDTO>, List<ProductModel>>(mainDishDTO);
            var drinks = mapper.Map<IEnumerable<ProductDTO>, List<ProductModel>>(drinksDTO);
            var desserts = mapper.Map<IEnumerable<ProductDTO>, List<ProductModel>>(dessertsDTO);

            ViewBag.MainDish = mainDish;
            ViewBag.Drinks = drinks;
            ViewBag.Desserts = desserts;

            return View(products);
        }


        protected override void Dispose(bool disposing)
        {
            _cartService.Dispose(); 
            _orderService.Dispose();   
            UserService.Dispose();
            base.Dispose(disposing);
        }

    
       
        public ActionResult Cart()
        {
            List<Item> cartItems = _cartService.GetCart();
            var coffees = _cartService.GetProducts("Coffee");
            ViewBag.Coffees = coffees.ToList();

            return View(cartItems);
        }
     
        [HttpPost]
        public JsonResult AddToCart(int ProductId,string category)
        {
            _cartService.AddToCart(ProductId,category);
            List<Item> cartItems = _cartService.GetCart();
    
            return Json(new { success = true, cartItems });

        }
    

        public JsonResult RemoveFromTheCart(int ProductId)
        {
            _cartService.RemoveFromTheCart(ProductId);

            List<Item> cartItems = _cartService.GetCart();
            return Json(new { success = true, cartItems });
        }
        [RedirectToRegister]
        [SessionTimeout]
        [HttpGet]
        [Authorize]
        public ActionResult Checkout()
        {
            var products = _cartService.GetCart();
            var user = UserService.GetUserById(User.Identity.GetUserId());
            ViewBag.User = user;
            ViewBag.Products = products;
            return View();
        }
        [Authorize]
        [SessionTimeout]
     
        public ActionResult SuccessfullOrder()
        {
            string userId = User.Identity.GetUserId();
            var orderDto = _orderService.GetOrdersByUserId(userId).LastOrDefault();
            var ItemsDTO = orderDto.Items.ToList();
            var productModel = new List<ProductModel>();
            foreach(var item in ItemsDTO)
            {
                var productDTO = _orderService.GetProductWithouCategory(item.ProductId);
                var product = new ProductModel
                {
                    Id = item.ProductId,
                    Name = productDTO.Name,
                    Price = productDTO.Price,
                    PathImage = productDTO.PathImage,
                    Quantity = item.Quantity,
                };
                productModel.Add(product);
            }

            if (orderDto == null || orderDto.ApplicationUserId != userId) return HttpNotFound();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderViewModel>()).CreateMapper();
            var order = mapper.Map<OrderDTO,OrderViewModel>(orderDto);
            order.PhoneNumber = orderDto.Phone;
            ViewBag.SuccessfulOrder = true;
            Session.Clear();

            ViewBag.CartItems = productModel;
            return View(order);
        }

        [HttpPost]
        [Authorize]
        [SessionTimeout]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Checkout(OrderViewModel model)
        {
            if (ModelState.IsValid)
            { 
                var user = await UserService.GetUserById(User.Identity.GetUserId());
                var cartItems = _cartService.GetCart();
                ViewBag.CartItems = cartItems.ToList();
             

                decimal delivery = 2.5m;
                decimal totalSumToPay = cartItems.Sum(item => (item.Quantity * item.Product.Price) + delivery);
                if (totalSumToPay > 0)
                {
                    var orderDto = new OrderDTO
                    {

                        ApplicationUserId = (user.Id).ToString(),
                        Appartment = model.Appartment,
                        StreetAddress = model.Address,
                        City = model.City,
                        Phone = model.PhoneNumber,
                        PostCode = model.PostCode,
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        TotalSumToPay = totalSumToPay,
                        
                    };
                    _orderService.MakeOrder(orderDto);
                   
                    return RedirectToAction("SuccessfullOrder", "Buy");
                }
                else
                {
                    return View(model);
                }

            }

            return View(model);  
        }

    }
}