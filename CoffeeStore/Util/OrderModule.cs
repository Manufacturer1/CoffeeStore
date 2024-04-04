using CoffeeStore.BuiesnessLogic.Interfaces;
using CoffeeStore.BuiesnessLogic.Services;
using Ninject.Modules;

namespace CoffeeStore.Util
{
    //;//Această metodă specifică că, atunci când o clasă are nevoie de un obiect care implementează IOrderService,
    //Ninject trebuie să furnizeze o instanță a clasei OrderService.
    public class OrderModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IOrderService>().To<OrderService>();
        }
    }
}