using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (connectionString: @"Server=DESKTOP-4E0IHUB\SQLEXPRESS;Database=Northwind;Trusted_Connection=True");
        }

        public DbSet<Product> Products{ get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}


     
