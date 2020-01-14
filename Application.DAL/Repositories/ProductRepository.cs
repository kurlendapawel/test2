using Application.DAL.Contexts;
using Application.DAL.Repositories.Base;
using Application.DAL.Repositories.Interfaces;
using Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.DAL.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(AppDataContext appDataContext) : base(appDataContext)
        {
        }
    }
}
