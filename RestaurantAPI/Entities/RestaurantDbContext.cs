using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Entities
{
    public class RestaurantDbContext : DbContext
    {
        private string _connectionString = "Server = DESKTOP-4T3IM66\\SQLEXPRESS01;Database=RestaurantDb;Trusted_Connection=True;";
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Address> Addresses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

    }
}
