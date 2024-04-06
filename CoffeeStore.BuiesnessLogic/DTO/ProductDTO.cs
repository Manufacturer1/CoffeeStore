using System;

namespace CoffeeStore.BuiesnessLogic.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
        public decimal Price { get; set; }
        public string Category { get; set; }

        public string PathImage { get; set; }

    }
}
