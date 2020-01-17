using Application.DAL.Contexts;
using Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.DAL.Repositories.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, IEntity
    {
        protected readonly AppDataContext _appDataContext;

        public RepositoryBase(AppDataContext appDataContext)
        {
            _appDataContext = appDataContext;
        }

        public int Add(TEntity entity)
        {
            _appDataContext.Set<TEntity>().Add(entity);
            _appDataContext.SaveChanges();

            return entity.Id;
        }

        public void Delete(int id)
        {
            var result = _appDataContext.Set<TEntity>().AsNoTracking().FirstOrDefault(x => x.Id == id);
            _appDataContext.Set<TEntity>().Remove(result);
            _appDataContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            var result = _appDataContext.Set<TEntity>().AsNoTracking();
            return result.ToList();
        }

        public TEntity GetSingle(int id)
        {
            var result = _appDataContext.Set<TEntity>().AsNoTracking();
            return result.FirstOrDefault(x => x.Id == id);
        }

        public void Update(TEntity entity)
        {
            _appDataContext.Set<TEntity>().Update(entity);
            _appDataContext.SaveChanges();
        }
    }
}
