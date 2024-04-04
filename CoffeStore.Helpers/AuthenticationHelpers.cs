using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using CoffeStore.

namespace CoffeStore.Helpers
{
    public class AuthenticationHelpers
    {
        private I
        public AuthenticationHelpers()
        public static async Task SignInAsync(HttpContext httpContext, ApplicationUser user)
        {
            var authenticationManager = httpContext.GetOwinContext().Authentication;

            // Create claims identity for the user
            var claimsIdentity = await httpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

            // Sign in the user
            authenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, claimsIdentity);
        }
    }
}
