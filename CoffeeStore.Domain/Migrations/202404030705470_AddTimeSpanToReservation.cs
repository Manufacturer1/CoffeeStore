namespace CoffeeStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTimeSpanToReservation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReservationTables", "ReservationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ReservationTables", "ReservationTime", c => c.Time(nullable: false, precision: 7));
            DropColumn("dbo.ReservationTables", "ReservationDateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReservationTables", "ReservationDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.ReservationTables", "ReservationTime");
            DropColumn("dbo.ReservationTables", "ReservationDate");
        }
    }
}
