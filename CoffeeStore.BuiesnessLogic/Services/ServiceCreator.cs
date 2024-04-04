using CoffeeStore.BuiesnessLogic.Interfaces;
using CoffeeStore.Domain.Repositories;

namespace CoffeeStore.BuiesnessLogic.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService()
        {
            return new UserService(new EFUnitOfWork());
        }
    }
}
