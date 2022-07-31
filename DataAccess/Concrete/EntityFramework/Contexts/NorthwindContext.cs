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
                (connectionString: @"Server=(localdb)\mssqllocaldb;initial catalog=northwind;integrated security=true");
        }

        public DbSet<Product> Products{ get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
