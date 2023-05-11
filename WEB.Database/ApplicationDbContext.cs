
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WEB.Database.Models;

namespace WEB.Database
{
    public class ApplicationDbContext :IdentityDbContext
    {
        public DbSet<User> Users { get; set; }  
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public ApplicationDbContext(DbContextOptions options)
            :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
            modelbuilder.Entity<Order>()
                .HasOne(c=>c.Country)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction); 
           

            modelbuilder.Entity<Order>()
                .HasOne(c => c.City)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
