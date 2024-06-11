namespace ECommerceMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableNameAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "DOP", c => c.DateTime());
            DropColumn("dbo.Products", "DateOfPurchase");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "DateOfPurchase", c => c.DateTime());
            DropColumn("dbo.Products", "DOP");
        }
    }
}
