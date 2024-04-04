namespace CoffeeStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteReservationTable : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM ReservationTables WHERE Id = 1");
            Sql("DELETE FROM ReservationTables WHERE Id = 2");
            Sql("DELETE FROM ReservationTables WHERE Id = 3");
            Sql("DELETE FROM ReservationTables WHERE Id = 4");
            Sql("DELETE FROM ReservationTables WHERE Id = 5");
            Sql("DELETE FROM ReservationTables WHERE Id = 6");
            Sql("DELETE FROM ReservationTables WHERE Id = 7");
            Sql("DELETE FROM ReservationTables WHERE Id = 8");
            Sql("DELETE FROM ReservationTables WHERE Id = 9");
            Sql("DELETE FROM ReservationTables WHERE Id = 10");
            Sql("DELETE FROM ReservationTables WHERE Id = 11");
            Sql("DELETE FROM ReservationTables WHERE Id = 12");
            Sql("DELETE FROM ReservationTables WHERE Id = 13");
            Sql("DELETE FROM ReservationTables WHERE Id = 14");
            Sql("DELETE FROM ReservationTables WHERE Id = 15");
            Sql("DELETE FROM ReservationTables WHERE Id = 16");
            Sql("DELETE FROM ReservationTables WHERE Id = 17");
            Sql("DELETE FROM ReservationTables WHERE Id = 18");
            Sql("DELETE FROM ReservationTables WHERE Id = 19");
            Sql("DELETE FROM ReservationTables WHERE Id = 20");


        }

        public override void Down()
        {
        }
    }
}
