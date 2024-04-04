using CoffeeStore.BuiesnessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.BuiesnessLogic.Interfaces
{
    public interface IEditProductService 
    {
        void UpdateProduct(ProductDTO productDto);
        void Dispose();
    }
}
