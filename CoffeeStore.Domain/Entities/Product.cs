using CoffeeStore.Domain.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoffeeStore.Domain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public string PathImage { get; set; }   


    }
}
