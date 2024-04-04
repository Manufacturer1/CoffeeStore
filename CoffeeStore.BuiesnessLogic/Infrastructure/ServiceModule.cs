
using CoffeeStore.BuiesnessLogic.Interfaces;
using CoffeeStore.Domain.Interfaces;
using CoffeeStore.Domain.Repositories;
using Ninject.Modules;

/*
 Acest cod configurează Ninject pentru a folosi implementarea EFUnitOfWork 
 * atunci când este cerută interfața IUnitOfWork, 
 * permițând astfel ca obiectele care depind de IUnitOfWork să fie construite corect și să fie furnizate cu conexiunea corectă către baza de date.
*/
namespace CoffeeStore.BuiesnessLogic.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
     public ServiceModule(string connectionString) {
            this.connectionString = connectionString;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
