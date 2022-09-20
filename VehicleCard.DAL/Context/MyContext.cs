using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        public MyContext()
        {
        }

        public IConfiguration Configuration { get; }
        public MyContext(DbContextOptions<MyContext> options):base(options){ }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("server=sql.athena.domainhizmetleri.com;database=abdulla1_vehicleCard;uid=abdulla1_vehicleCard;pwd=nk3Iv_945");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DataInitializer.Seed(modelBuilder);
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
        }

        public DbSet<AppUser> AppUsers { get; set; }

    }
}
