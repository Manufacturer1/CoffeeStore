using CoffeeStore.BuiesnessLogic.DTO;
using CoffeeStore.Domain.Entities;
using System.Collections.Generic;

namespace CoffeeStore.BuiesnessLogic.Interfaces
{
    public interface ICartService
    {
        void AddToCart(int ProductId,string category);
        void RemoveFromTheCart(int ProductId);
        List<Item> GetCart();
        void ClearSession();
        ProductDTO GetProduct(int? id,string category);
        IEnumerable<ProductDTO> GetProducts(string category);
        IEnumerable<ProductDTO> RetrieveAllProducts();
        void SetDiscount(DiscountDTO discountDto);
        IEnumerable<DiscountDTO> GetAllDiscounts();
        decimal CalculateTotalPrice();

        IEnumerable<DeliveryCostDTO> GetAllDeliveriesCost();
        void SetDelivery(DeliveryCostDTO deliveryCostDTO);
        void Dispose();

    }
}
