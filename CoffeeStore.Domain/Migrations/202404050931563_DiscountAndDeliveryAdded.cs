namespace CoffeeStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DiscountAndDeliveryAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Discount", c => c.Int());
            AddColumn("dbo.Products", "Delivery", c => c.Int());
            AddColumn("dbo.Products", "ExpirationTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ExpirationTime");
            DropColumn("dbo.Products", "Delivery");
            DropColumn("dbo.Products", "Discount");
        }
    }
}
