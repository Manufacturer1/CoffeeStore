using CoffeeStore.BuiesnessLogic.Interfaces;
using CoffeeStore.BuiesnessLogic.Services;
using Ninject.Modules;

namespace CoffeeStore.Util
{
    public class ReservationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IReservationService>().To<ReservationService>();
        }
    }
}