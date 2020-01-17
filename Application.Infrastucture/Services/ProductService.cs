using Application.DAL.Repositories.Interfaces;
using Application.Domain.Entities;
using Application.Infrastucture.DTOs;
using Application.Infrastucture.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

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

        public int Add(ProductDto entity)
        {
            var product = _mapper.Map<Product>(entity);
            return _productRepository.Add(product);
        }

        public bool Delete(int id)
        {
            var entity = _productRepository.GetSingle(id);

            if (entity == null)
                return false;

            _productRepository.Delete(id);
            return true;
        }

        public ProductDto Get(int id)
        {
            var result = _productRepository.GetSingle(id);
            return _mapper.Map<ProductDto>(result);
        }

        public IEnumerable<ProductDto> GetAll()
        {
            var result = _productRepository.GetAll();

            return _mapper.Map<List<ProductDto>>(result);
        }

        public bool Update(ProductDto entity, int id)
        {
            var product = _productRepository.GetSingle(id);

            if (product == null)
                return false;

            product.Name = entity.Name;
            product.Price = entity.Price;

            _productRepository.Update(product);

            return true;
        }

        public int GetSumPricesAllproducts()
        {
            var products = GetAll().ToList();

            var sum = products.Sum(x => x.Price);

            return sum;
        }
    }
}
