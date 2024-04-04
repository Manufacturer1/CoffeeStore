using CoffeeStore.BuiesnessLogic.DTO;
using System.Collections.Generic;

namespace CoffeeStore.BuiesnessLogic.Interfaces
{
    public interface IOrderService
    {
        void MakeOrder(OrderDTO orderDTO);
        ProductDTO GetProduct(int? id,string category);
        IEnumerable<ProductDTO> GetProducts(string category);
        IEnumerable<OrderDTO> GetOrders(string category);
        OrderDTO GetOrder(int id);
        IEnumerable<OrderDTO> GetOrdersByUserId(string id);
        bool DeleteOrdersByUserId(string userId);
        ProductDTO GetProductWithouCategory(int productId);
        void Dispose();
    }
}
