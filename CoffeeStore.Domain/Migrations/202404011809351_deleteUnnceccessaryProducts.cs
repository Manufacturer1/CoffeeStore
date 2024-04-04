namespace CoffeeStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteUnnceccessaryProducts : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Products WHERE Id = 23");
            Sql("DELETE FROM Products WHERE Id = 24");
            Sql("DELETE FROM Products WHERE Id = 25");

        }

        public override void Down()
        {
        }
    }
}
