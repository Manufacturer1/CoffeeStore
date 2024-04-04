using CoffeeStore.Domain.Entities;
using Microsoft.AspNet.Identity;

namespace CoffeeStore.Domain.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store) { }

    }
}
