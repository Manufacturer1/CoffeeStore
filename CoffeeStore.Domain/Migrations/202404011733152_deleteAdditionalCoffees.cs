namespace CoffeeStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteAdditionalCoffees : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Orders WHERE Id = 3");
            
        }
        
        public override void Down()
        {
        }
    }
}
