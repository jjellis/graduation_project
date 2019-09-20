using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using LubbockLocalRestaurant.Core.Models;



namespace LubbockLocalRestaurantAPI.Infrastructure.Data
{
    public class AppDbContext: IdentityDbContext
    {
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);  
        }
        public AppDbContext(DbContextOptions<AppDbContext> options)
  : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        //{
        //    dbContextOptionsBuilder.UseSqlite("Data Source = ../LubbockLocalRestaurantAPI.Infrastructure/Restaurants.db");
        //}
    }
}
