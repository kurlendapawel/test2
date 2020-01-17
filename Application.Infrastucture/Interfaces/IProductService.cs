using Application.Infrastucture.DTOs;
using System.Collections.Generic;

namespace Application.Infrastucture.Interfaces
{
    public interface IProductService
    {
        bool Delete(int id);
        IEnumerable<ProductDto> GetAll();
        ProductDto Get(int id);
        int Add(ProductDto entity);
        bool Update(ProductDto entity, int id);
        int GetSumPricesAllproducts();
    }
}
