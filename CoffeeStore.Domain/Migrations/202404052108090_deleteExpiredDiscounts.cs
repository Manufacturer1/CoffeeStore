namespace CoffeeStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteExpiredDiscounts : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Discounts WHERE Id = 1");
            Sql("DELETE FROM Discounts WHERE Id = 4");
            Sql("DELETE FROM Discounts WHERE Id = 9");
            Sql("DELETE FROM Discounts WHERE Id = 13");

        }

        public override void Down()
        {
        }
    }
}
