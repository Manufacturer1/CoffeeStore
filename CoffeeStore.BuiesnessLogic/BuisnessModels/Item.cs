using CoffeeStore.BuiesnessLogic.DTO;

namespace CoffeeStore.Domain.Entities
{
    public class Item
    {
        public ProductDTO Product { get; set; }
        public int Quantity { get; set; }

    }
}
