using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ECommerceMVC.Migrations;
namespace ECommerceMVC.Models
{
    public class CompanyDBContext:DbContext
    {
        public CompanyDBContext():base("SqlConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CompanyDBContext, Configuration>());
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}