using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TuzluSozluk.Domain.Entities.Common;

namespace TuzluSozluk.Application.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        DbSet<TEntity> Table { get; }
        IQueryable<TEntity> GetAll(bool tracking = true);
        IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> method, bool tracking = true);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> method, bool tracking = true);
        Task<TEntity> GetByIdAsync(int id, bool tracking = true);
        Task<bool> AddAsync(TEntity entity);
        Task<bool> AddRangeAsync(List<TEntity> entities);
        bool Update(TEntity entity);
        bool Remove(TEntity entity);
        Task<bool> RemoveAsync(int id);
        bool RemoveRange(List<TEntity> entities);
        Task<int> SaveAsync();
    }
}
