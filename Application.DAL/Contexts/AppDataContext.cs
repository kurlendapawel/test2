using Application.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DAL.Contexts
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, Name = "Lavender heart", Price = 9 },
                new Product() { Id = 2, Name = "Personalised cufflinks", Price = 10 },
                new Product() { Id = 3, Name = "Kids T-shirt", Price = 19 }
                );
        }
    }
}
