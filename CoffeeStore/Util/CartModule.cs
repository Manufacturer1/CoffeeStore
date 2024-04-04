using CoffeeStore.BuiesnessLogic.Interfaces;
using CoffeeStore.BuiesnessLogic.Services;
using Ninject.Modules;

namespace CoffeeStore.Util
{
    public class CartModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICartService>().To<CartService>();
        }
    }
}