using CoffeeStore.BuiesnessLogic.Interfaces;
using CoffeeStore.BuiesnessLogic.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(CoffeeStore.App_Start.Startup))]

namespace CoffeeStore.App_Start
{
    public class Startup
    {
        IServiceCreator serviceCreator = new ServiceCreator();

        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });

        }
        private IUserService CreateUserService()
        {
            return serviceCreator.CreateUserService();
        }
    }
}