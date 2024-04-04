using CoffeeStore.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Reflection.Emit;

namespace CoffeeStore.Domain.EF
{
    public class AppContext :IdentityDbContext<ApplicationUser>
    {
        
      
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
        public DbSet<ClientProfile> ClientProfiles { get; set; }
        public DbSet<Order> Orders { get; set; }    
        public DbSet<ReservationTable> Reservations { get; set; }

        public AppContext() : base("DefaultConnection1") { }
        public static AppContext Create()
        {
            return new AppContext();
        }

    }
}