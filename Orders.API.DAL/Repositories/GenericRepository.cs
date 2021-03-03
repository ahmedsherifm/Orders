using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Orders.API.DAL.Interfaces;
using Orders.API.Entities.Models;

namespace Orders.API.DAL.Repositories
{
    public class GenericRepository: IGenericRepository
    {
        private readonly OrdersContext _ordersContext;

        public GenericRepository(OrdersContext ordersContext)
        {
            _ordersContext = ordersContext;
        }
        
        public IQueryable<TEntity> GetQueryAsQueryable<TEntity>() where TEntity : BaseEntity
        {
            return _ordersContext.Set<TEntity>().AsQueryable().AsTracking();
        }

        public IQueryable<TEntity> GetQueryAsQueryableWithInclude<TEntity>(string includeProperties) where TEntity : BaseEntity
        {
            var query = GetQueryAsQueryable<TEntity>();
            return includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public async Task<TEntity> GetByIdAsync<TEntity>(Guid id, string includeProperties) where TEntity : BaseEntity
        {
            var query = GetQueryAsQueryableWithInclude<TEntity>(includeProperties);
            return await query.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<TEntity>> GetListAsync<TEntity>(string includeProperties) where TEntity : BaseEntity
        {
            var query = GetQueryAsQueryableWithInclude<TEntity>(includeProperties);
            return await query.ToListAsync();
        }

        public async Task<List<TEntity>> GetListAsync<TEntity>(Expression<Func<TEntity, bool>> filter,
            string includeProperties) where TEntity : BaseEntity
        {
            var query = GetQueryAsQueryableWithInclude<TEntity>(includeProperties);
            return await query.Where(filter).ToListAsync();
        }

        public async Task<TEntity> GetFirstAsync<TEntity>(Expression<Func<TEntity, bool>> filter,
            string includeProperties) where TEntity : BaseEntity
        {
            var query = GetQueryAsQueryableWithInclude<TEntity>(includeProperties);
            return await query.FirstOrDefaultAsync(filter);
        }

        public void Add<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            _ordersContext.Set<TEntity>().Add(entity);
        }

        public void AddRange<TEntity>(List<TEntity> entities) where TEntity : BaseEntity
        {
            _ordersContext.Set<TEntity>().AddRange(entities);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            _ordersContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            _ordersContext.Entry(entity).State = EntityState.Deleted;
        }

        public async Task<int> SaveAsync()
        {
            foreach (var entry in _ordersContext.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                if (!(entry.Entity is BaseEntity entity)) continue;
                switch (entry.State)
                {
                    case EntityState.Added:
                        entity.CreatedDate = DateTime.UtcNow;
                        entity.UpdatedDate = DateTime.UtcNow;
                        entity.Deleted = false;
                        break;
                    case EntityState.Modified:
                        entity.UpdatedDate = DateTime.UtcNow;
                        entry.Property(nameof(entity.CreatedDate)).IsModified = false;
                        break;
                    case EntityState.Detached:
                    case EntityState.Unchanged:
                    case EntityState.Deleted:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return await _ordersContext.SaveChangesAsync();
        }
    }
}
