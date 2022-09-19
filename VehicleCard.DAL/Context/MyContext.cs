using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleCard.MAP.Configuration;
using VehilceCard.ENT.Models;

namespace VehicleCard.DAL.Context
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> options):base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DataInitializer.Seed(modelBuilder);
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
        }

        public DbSet<AppUser> AppUsers { get; set; }

    }
}
