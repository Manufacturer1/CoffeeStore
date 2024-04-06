namespace CoffeeStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DiscardChanges : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Discount");
            DropColumn("dbo.Products", "Delivery");
            DropColumn("dbo.Products", "ExpirationTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ExpirationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "Delivery", c => c.Int());
            AddColumn("dbo.Products", "Discount", c => c.Int());
        }
    }
}
