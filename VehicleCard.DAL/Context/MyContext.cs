using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VehilceCard.ENT.Models;

namespace VehicleCard.DAL.Context
{
    public class MyContext:DbContext
    {
        public MyContext()
        {
        }

        public IConfiguration Configuration { get; }
        public MyContext(DbContextOptions<MyContext> options):base(options){ }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DataInitializer.Seed(modelBuilder);
        }

        public DbSet<Model> Models { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductsWithVehicles> ProductsWithVehicle { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

    }
}
