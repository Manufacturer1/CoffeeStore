using CoffeeStore.Domain.Entities;
using CoffeeStore.Domain.Identity;
using System;
using System.Threading.Tasks;

/*
 * definește un set de metode și proprietăți pe care o clasă trebuie să le implementeze pentru a gestiona tranzacțiile și operațiile pe baza de date. 
 */
namespace CoffeeStore.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<ReservationTable> ReservationsRepository { get; }
        IRepository<Product> Products { get; }
        IRepository<Order> Orders { get; }
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
      
        Task SaveAsync();
        void Save();
    }
}
