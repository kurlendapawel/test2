using Application.DAL.Repositories.Base;
using Application.DAL.Repositories.Interfaces;
using Application.Domain.Entities;
using Application.Infrastucture.DTOs;
using Application.Infrastucture.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infrastucture.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(
            IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<int> Add(ProductDto entity)
        {
            var product = _mapper.Map<Product>(entity);
            return await _productRepository.AddAsync(product);
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _productRepository.GetSingleAsync(id);

            if (entity == null)
                return false;

            await _productRepository.DeleteAsync(id);
            return true;
        }

        public async Task<ProductDto> Get(int id)
        {
            var result = await _productRepository.GetSingleAsync(id);
            return _mapper.Map<ProductDto>(result);
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var result = await _productRepository.GetAllAsync();

            return _mapper.Map<List<ProductDto>>(result);
        }

        public async Task<bool> Update(ProductDto entity, int id)
        {
            var product = await _productRepository.GetSingleAsync(id);

            if (product == null)
                return false;

            product.Name = entity.Name ?? product.Name;
            product.Price = entity.Price ?? product.Price;

            await _productRepository.UpdateAsync(product);

            return true;
        }
    }
}
