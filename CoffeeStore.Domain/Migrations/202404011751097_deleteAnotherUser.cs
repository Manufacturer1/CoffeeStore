namespace CoffeeStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteAnotherUser : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM AspNetUsers WHERE UserName = 'Oleg123' ");
        }
        
        public override void Down()
        {
        }
    }
}
