namespace ECommerceMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ECommerceMVC.Models.CompanyDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ECommerceMVC.Models.CompanyDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Brands.AddOrUpdate(new Models.Brand { BrandID = 1, BrandName = "Iphone" });
            context.Categories.AddOrUpdate(new Models.Category { CategoryID = 1, CategoryName = "Electronics" });
            context.Products.AddOrUpdate(new Models.Product { ProductID = 1, ProductName = "IPhoneX", CategoryID = 1, BrandID = 1, Photo = null, DOP = DateTime.Now, Price = 123, Active = true, AvailabilityStatus = "InStock" });
        }
    }
}
