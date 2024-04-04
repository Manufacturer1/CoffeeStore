namespace CoffeeStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedDataAndTimeFormat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ReservationTables", "ReservationDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ReservationTables", "ReservationDate", c => c.DateTime(nullable: false));
        }
    }
}
