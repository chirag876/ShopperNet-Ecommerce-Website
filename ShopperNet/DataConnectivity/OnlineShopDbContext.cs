using Microsoft.EntityFrameworkCore;
using ShopperNet.Models;

namespace ShopperNet.DataConnectivity
{
    public class OnlineShopDbContext:DbContext
    {
        public OnlineShopDbContext(DbContextOptions options):base(options)
        {
            
        }

       public DbSet<ShopRegistration> Users { get; set; }
       public DbSet<Profile> profile { get; set; }
       public DbSet<Items> Items { get; set; }
       public DbSet<Cart> ShopperCart { get; set; }
       public DbSet<Admin> Admin { get; set; }
       public DbSet<Orders> orders { get; set; }
       public DbSet<shippingadd> shippingadd { get; set; }
      



       public DbSet<ShopperNet.Models.ShopLogin> ShopLogin { get; set; }
      



       public DbSet<ShopperNet.Models.Profile> Profile { get; set; }
      



       public DbSet<ShopperNet.Models.shippingadd> Address { get; set; }
      



       
    }

    
}
