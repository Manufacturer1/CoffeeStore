namespace CoffeeStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetCoffee : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Products (Name, Price,Category, Discriminator) VALUES ('Cappuccino', 5.90, 'Coffee' ,'Coffee')");
            Sql("INSERT INTO Products (Name, Price,Category, Discriminator) VALUES ('Latte', 5.90, 'Coffee' ,'Coffee')");
            Sql("INSERT INTO Products (Name, Price, Category ,Discriminator) VALUES ('Macchiato', 5.90, 'Coffee' ,'Coffee')");
            Sql("INSERT INTO Products (Name, Price, Category,Discriminator) VALUES ('Espresso', 5.90, 'Coffee','Coffee')");
        }
        
        public override void Down()
        {
        }
    }
}
