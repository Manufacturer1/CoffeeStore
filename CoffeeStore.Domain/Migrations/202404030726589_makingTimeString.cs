namespace CoffeeStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makingTimeString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ReservationTables", "ReservationTime", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ReservationTables", "ReservationTime", c => c.Time(nullable: false, precision: 7));
        }
    }
}
