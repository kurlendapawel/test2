using Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.DAL.Repositories.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : class, IEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetSingle(int id);
        int Add(TEntity entity);
        void Delete(int id);
        void Update(TEntity entity);
    }
}
