using Application.Domain.Entities;
using Application.Infrastucture.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infrastucture.Interfaces
{
    public interface IProductService
    {
        bool Delete(int id);
        IEnumerable<ProductDto> GetAll();
        ProductDto Get(int id);
        int Add(ProductDto entity);
        bool Update(ProductDto entity, int id);
    }
}
