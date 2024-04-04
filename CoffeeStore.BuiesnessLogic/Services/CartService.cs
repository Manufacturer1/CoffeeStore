using AutoMapper;

using CoffeeStore.BuiesnessLogic.DTO;
using CoffeeStore.BuiesnessLogic.Infrastructure;
using CoffeeStore.BuiesnessLogic.Interfaces;
using CoffeeStore.Domain.Entities;
using CoffeeStore.Domain.Interfaces;
using CoffeeStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeStore.BuiesnessLogic.Services
{
    public class CartService : ICartService
    {

        private IUnitOfWork DataBase { get; set; }
        public CartService(IUnitOfWork uow) { DataBase = uow; }
        
        public void AddToCart(int ProductId, string category)
        { 
            var products = DataBase.Products.Get(ProductId, category);  
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            var product = mapper.Map<Product, ProductDTO>(products);
    
            List<Item> cart = GetCart();
       
            
          
            Item newItem = new Item {Product = product,Quantity = 1};
           
            int index = IsInCart(cart, ProductId);
            if (index != -1)
            {
                cart[index].Quantity++;
            }
            else
            {
               
                cart.Add(newItem);
            }

            UpdateCart(cart);

        }
        private void UpdateCart(List<Item> cart)
        {
            HttpContext.Current.Session["cart"] = cart;
        }
        private int IsInCart(List<Item> cart, int ProductId)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id == ProductId)
                {
                    return i;
                }
            }
            return -1;
        }
        public void ClearSession()
        {

            HttpContext.Current.Session.Clear();
        }
        public void RemoveFromTheCart(int ProductId)
        {
            List<Item> cart = GetCart();
            int index = IsInCart(cart, ProductId);
            if (cart[index].Quantity > 1)
            {

                cart[index].Quantity--;
            }
            else
            {
                cart.RemoveAt(index);
            }
            UpdateCart(cart);
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }

        public List<Item> GetCart()
        {
            if (HttpContext.Current.Session["cart"] == null)
            {
                HttpContext.Current.Session["cart"] = new List<Item>();
            }
            return (List<Item>)HttpContext.Current.Session["cart"];
        }

        public IEnumerable<ProductDTO> GetProducts(string category)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            var products = DataBase.Products.GetAll(category);
            return mapper.Map<IEnumerable<Product>,List<ProductDTO>>(products);
        }

        public ProductDTO GetProduct(int? id,string category)
        {
            if (id == null) throw new ValidationException("The ID was not found!", "");
            var product = DataBase.Products.Get(id.Value,category);
                if (product == null) throw new ValidationException("The Coffee was not found", "");

            return new ProductDTO { Id = product.Id, Name = product.Name, Price = product.Price,Category = category,PathImage = product.PathImage };
        }
        public IEnumerable<ProductDTO> RetrieveAllProducts()
        {
            var products = DataBase.Products.RetrieveAllProducts();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product,ProductDTO>()).CreateMapper();
            var productsDTO = mapper.Map<IEnumerable<Product>,IEnumerable<ProductDTO>>(products);
            return productsDTO;
        }
     
    }
}
