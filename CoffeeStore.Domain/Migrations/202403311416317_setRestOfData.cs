namespace CoffeeStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setRestOfData : DbMigration
    {
        public override void Up()
        {

            // Main Dishes
            Sql("INSERT INTO Products (Name, Price, Category) VALUES ('Beef Stir-Fry', 12.50, 'MainDish')");
            Sql("INSERT INTO Products (Name, Price, Category) VALUES ('BBQ Ribs', 11.49, 'MainDish')");
            Sql("INSERT INTO Products (Name, Price, Category) VALUES ('Beef Stroganoff', 14.99, 'MainDish')");
            Sql("INSERT INTO Products (Name, Price, Category) VALUES ('Chicken Alfredo', 13.99, 'MainDish')");
            Sql("INSERT INTO Products (Name, Price, Category) VALUES ('Shrimp Scampi', 14.49, 'MainDish')");
            Sql("INSERT INTO Products (Name, Price, Category) VALUES ('Grilled Salmon', 15.99, 'MainDish')");

            // Drinks
            Sql("INSERT INTO Products (Name, Price, Category) VALUES ('Lemonade Juice', 8.99, 'Drink')");
            Sql("INSERT INTO Products (Name, Price, Category) VALUES ('Champagne', 9.49, 'Drink')");
            Sql("INSERT INTO Products (Name, Price, Category) VALUES ('Mojito', 8.99, 'Drink')");
            Sql("INSERT INTO Products (Name, Price, Category) VALUES ('Beer', 7.99, 'Drink')");
            Sql("INSERT INTO Products (Name, Price, Category) VALUES ('Pineapple Juice', 8.99, 'Drink')");
            Sql("INSERT INTO Products (Name, Price, Category) VALUES ('Strawberry Banana Smoothie', 10.99, 'Drink')");

            // Desserts
            Sql("INSERT INTO Products (Name, Price, Category) VALUES ('Tiramisu', 8.49, 'Dessert')");
            Sql("INSERT INTO Products (Name, Price, Category) VALUES ('Blueberry Pancakes', 9.49, 'Dessert')");
            Sql("INSERT INTO Products (Name, Price, Category) VALUES ('Strawberry Tart', 7.99, 'Dessert')");
            Sql("INSERT INTO Products (Name, Price, Category) VALUES ('Mixed Berry Crisp', 8.49, 'Dessert')");
            Sql("INSERT INTO Products (Name, Price, Category) VALUES ('Chocolate Brownie Sundae', 8.99, 'Dessert')");
            Sql("INSERT INTO Products (Name, Price, Category) VALUES ('Red Velvet Cake', 7.49, 'Dessert')");
        }
        
        public override void Down()
        {
        }
    }
}
