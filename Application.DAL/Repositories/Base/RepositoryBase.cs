using Application.DAL.Contexts;
using Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.DAL.Repositories.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, IEntity
    {
        protected readonly AppDataContext _appDataContext;

        public RepositoryBase(AppDataContext appDataContext)
        {
            _appDataContext = appDataContext;
        }

        public async Task<int> AddAsync(TEntity entity)
        {
            await _appDataContext.Set<TEntity>().AddAsync(entity);
            await _appDataContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var result = _appDataContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            _appDataContext.Set<TEntity>().Remove(result.Result);
            await _appDataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var result = _appDataContext.Set<TEntity>().AsNoTracking();
            return await result.ToListAsync();
        }

        public async Task<TEntity> GetSingleAsync(int id)
        {
            var result = _appDataContext.Set<TEntity>().AsNoTracking();
            return await result.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _appDataContext.Set<TEntity>().Update(entity);
            await _appDataContext.SaveChangesAsync();
        }
    }
}
