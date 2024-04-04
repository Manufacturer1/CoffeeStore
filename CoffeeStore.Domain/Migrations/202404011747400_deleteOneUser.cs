namespace CoffeeStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteOneUser : DbMigration
    {
        public override void Up()
        {

            Sql("DELETE FROM Orders WHERE Id = 5");
            Sql("DELETE FROM Orders WHERE Id = 6");
            Sql("DELETE FROM Orders WHERE Id = 7");
           


        }

        public override void Down()
        {
        }
    }
}
