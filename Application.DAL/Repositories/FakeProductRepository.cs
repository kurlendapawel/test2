using Application.DAL.Contexts;
using Application.DAL.Repositories.Base;
using Application.DAL.Repositories.Interfaces;
using Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.DAL.Repositories
{
    public class FakeProductRepository : IProductRepository
    {
        private static List<Product> Products = new List<Product>()
        {
            new Product() { Id = 1, Name = "Name_1", Price = "15" },
            new Product() { Id = 2, Name = "Name_2", Price = "30" },
            new Product() { Id = 3, Name = "Name_3", Price = "45" }
        };


        public async Task<int> AddAsync(Product product)
        {
            await Task.Delay(100);

            Products.Add(product);

            return product.Id;
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Delay(100);

            var entity = Products.FirstOrDefault(x => x.Id == id);

            Products.Remove(entity);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            await Task.Delay(100);

            return Products;
        }

        public async Task<Product> GetSingleAsync(int id)
        {
            await Task.Delay(100);

            return Products.FirstOrDefault(x => x.Id == id);
        }

        public async Task UpdateAsync(Product product)
        {
            await Task.Delay(100);

            var entity = Products.FirstOrDefault(x => x.Id == product.Id);

            entity.Name = product.Name;
            entity.Price = product.Price;
        }
    }
}
