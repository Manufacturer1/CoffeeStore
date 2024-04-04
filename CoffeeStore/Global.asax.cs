using CoffeeStore.BuiesnessLogic.Infrastructure;
using CoffeeStore.Util;
using Ninject.Modules;
using Ninject;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject.Web.Mvc;
using AutoMapper;

namespace CoffeeStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);



            NinjectModule orderModule = new OrderModule();
            NinjectModule reservationModule = new ReservationModule();
            NinjectModule editModule = new EditModule();
            NinjectModule serviceModule = new ServiceModule("Connection");
            NinjectModule cartModule = new CartModule();    
            var kernel = new StandardKernel(serviceModule,cartModule,orderModule,editModule,reservationModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));


         
        }
    }
}
