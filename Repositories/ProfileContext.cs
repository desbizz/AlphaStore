using System.IO;
using AlphaStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AlphaStore.Repositories
{
   public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ProfileContext>
    {
        public ProfileContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ProfileContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new ProfileContext(builder.Options);
        }
    }
    public class ProfileContext:DbContext{

         public ProfileContext(DbContextOptions<ProfileContext> options) : base(options)
        {

        }
       public DbSet<Product> Products { get; set; }
        public DbSet<StockPurchase> StockPurchases { get; set; }
         public DbSet<Category> Categories { get; set; }
          public DbSet<Customer> Customers { get; set; }
           public DbSet<Order> Orders { get; set; }
            public DbSet<Quantity> Quantitys { get; set; }
             public DbSet<Staff> Staffs { get; set; }
              public DbSet<Store> Stores { get; set; }
               public DbSet<Supplier> Suppliers { get; set; }

       
         
             
         protected override void OnModelCreating(ModelBuilder builder)
        {            
            // builder.Entity<Payments>().HasKey(ia => new { ia.ReceiptNumber, ia.StudentId }) ;
           
            
           // builder.Entity<IndividualDeduction>().HasKey(id => new { id.NameId,id.IndividualId });
        }
    }
}