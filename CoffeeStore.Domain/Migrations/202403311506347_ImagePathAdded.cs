namespace CoffeeStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImagePathAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "PathImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "PathImage");
        }
    }
}
