using Microsoft.EntityFrameworkCore;
using VehilceCard.ENT.Models;

namespace VehicleCard.DAL.Context
{
    public static class DataInitializer
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<AppUser>().HasData(
            //    new AppUser()
            //    {
            //        Id = 1,
            //        UserMail = "NCE@netlog.com",
            //        UserFullName = "Nureddin Cüneyd ERDOĞAN",
            //        UserPass = "123",
            //        Status = true
            //
            //    });
            modelBuilder.Entity<Model>().HasData(
                new Model()
                {
                    Id = 1,
                    BrandName = "Ford",
                    ModelName = "F-Max",
                    CapacityKG = 5000,
                    CapacityM3 = 10000,
                    Status = true

                });
            modelBuilder.Entity<Model>().HasData(
                new Model()
                {
                    Id = 2,
                    BrandName = "BMC",
                    ModelName = "TGR 1846 ESS",
                    CapacityKG = 5000,
                    CapacityM3 = 10000,
                    Status = true

                });
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle()
                {
                    Id = 1,
                    Plate = "34NE4906",
                    vModelId = 2,
                    Location = "İstanbul",
                    VehicleImgUrl = "https://cdn.cetas.com.tr/Download/resources/f-max-1_4585289922_-1x-1_false.jpg",
                    Status = true

                });
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle()
                {
                    Id = 2,
                    Plate = "34NE3406",
                    vModelId = 1,
                    Location = "İstanbul",
                    VehicleImgUrl = "https://bmctugra.com/_cache/croped/gallery_2019-01-10_11-53-294-1044x623.jpg",
                    Status = true

                });

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    ProImgUrl="",
                    ProName = "",
                    ProKG=150,
                    ProM3=300,
                    Status = true

                });

            modelBuilder.Entity<ProductsWithVehicles>().HasData(
                new ProductsWithVehicles()
                {
                    Id = 1,
                    VehiclesId = 1,
                    ProductsId = 1,
                    AvailableCapKG = 1500,
                    AvailableCapM3 = 350,
                    Status = true

                });

        }
    }
}
