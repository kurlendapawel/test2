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
        Task<bool> Delete(int id);
        Task<IEnumerable<ProductDto>> GetAll();
        Task<ProductDto> Get(int id);
        Task<int> Add(ProductDto entity);
        Task<bool> Update(ProductDto entity, int id);
    }
}
