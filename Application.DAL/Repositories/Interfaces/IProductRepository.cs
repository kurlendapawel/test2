using Application.DAL.Repositories.Base;
using Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DAL.Repositories.Interfaces
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
    }
}
