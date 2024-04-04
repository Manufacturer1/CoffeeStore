using AutoMapper;
using CoffeeStore.BuiesnessLogic.DTO;
using CoffeeStore.BuiesnessLogic.Interfaces;
using CoffeeStore.Domain.Entities;
using CoffeeStore.Domain.Interfaces;

namespace CoffeeStore.BuiesnessLogic.Services
{
    public class EditProductService : IEditProductService
    {
        private IUnitOfWork DataBase { get; set; }
        public EditProductService(IUnitOfWork uow) { DataBase = uow; }

        public void UpdateProduct(ProductDTO productDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, Product>()).CreateMapper();
            var product = mapper.Map<ProductDTO, Product>(productDto);
            DataBase.Products.Update(product);
            DataBase.Save();
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}
