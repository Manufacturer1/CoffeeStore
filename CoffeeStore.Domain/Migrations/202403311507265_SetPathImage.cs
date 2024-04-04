namespace CoffeeStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetPathImage : DbMigration
    {
        public override void Up()
        {
            //Coffe Images
            Sql("UPDATE Products SET PathImage = '/Content/images/menu-1.jpg' WHERE Id = 1");
            Sql("UPDATE Products SET PathImage = '/Content/images/menu-2.jpg' WHERE Id = 2");
            Sql("UPDATE Products SET PathImage = '/Content/images/menu-3.jpg' WHERE Id = 3");
            Sql("UPDATE Products SET PathImage = '/Content/images/menu-4.jpg' WHERE Id = 4");

            //MainDish imaged
            Sql("UPDATE Products SET PathImage = '/Content/images/dish-1.jpg' WHERE Id = 5");
            Sql("UPDATE Products SET PathImage = '/Content/images/dish-2.jpg' WHERE Id = 6");
            Sql("UPDATE Products SET PathImage = '/Content/images/dish-3.jpg' WHERE Id = 7");
            Sql("UPDATE Products SET PathImage = '/Content/images/dish-4.jpg' WHERE Id = 8");
            Sql("UPDATE Products SET PathImage = '/Content/images/dish-5.jpg' WHERE Id = 9");
            Sql("UPDATE Products SET PathImage = '/Content/images/dish-6.jpg' WHERE Id = 10");

            //Drinks Images
            Sql("UPDATE Products SET PathImage = '/Content/images/drink-1.jpg' WHERE Id = 11");
            Sql("UPDATE Products SET PathImage = '/Content/images/drink-2.jpg' WHERE Id = 12");
            Sql("UPDATE Products SET PathImage = '/Content/images/drink-3.jpg' WHERE Id = 13");
            Sql("UPDATE Products SET PathImage = '/Content/images/drink-4.jpg' WHERE Id = 14");
            Sql("UPDATE Products SET PathImage = '/Content/images/drink-5.jpg' WHERE Id = 15");
            Sql("UPDATE Products SET PathImage = '/Content/images/drink-6.jpg' WHERE Id = 16");

            //Desserts Images
            Sql("UPDATE Products SET PathImage = '/Content/images/dessert-1.jpg' WHERE Id = 17");
            Sql("UPDATE Products SET PathImage = '/Content/images/dessert-2.jpg' WHERE Id = 18");
            Sql("UPDATE Products SET PathImage = '/Content/images/dessert-3.jpg' WHERE Id = 19");
            Sql("UPDATE Products SET PathImage = '/Content/images/dessert-4.jpg' WHERE Id = 20");
            Sql("UPDATE Products SET PathImage = '/Content/images/dessert-5.jpg' WHERE Id = 21");
            Sql("UPDATE Products SET PathImage = '/Content/images/dessert-6.jpg' WHERE Id = 22");


        }

        public override void Down()
        {
        }
    }
}
