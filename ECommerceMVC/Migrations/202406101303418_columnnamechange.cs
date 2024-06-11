namespace ECommerceMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class columnnamechange : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "DOP", newName: "DateOfPurchase");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Products", name: "DateOfPurchase", newName: "DOP");
        }
    }
}
