namespace CoffeeStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedReservationModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReservationTables", "ReservationDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.ReservationTables", "ReservationDate");
            DropColumn("dbo.ReservationTables", "ReservationTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReservationTables", "ReservationTime", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.ReservationTables", "ReservationDate", c => c.DateTime(nullable: false, storeType: "date"));
            DropColumn("dbo.ReservationTables", "ReservationDateTime");
        }
    }
}
