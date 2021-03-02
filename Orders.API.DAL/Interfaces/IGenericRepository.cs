using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Orders.API.Entities.Models;

namespace Orders.API.DAL.Interfaces
{
    public interface IGenericRepository
    {
        Task<TEntity> GetByIdAsync<TEntity>(Guid id) where TEntity : BaseEntity;
        Task<List<TEntity>> GetListAsync<TEntity>() where TEntity : BaseEntity;
        public Task<List<TEntity>> GetListAsync<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : BaseEntity;
        public Task<TEntity> GetFirstAsync<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : BaseEntity;
        void Add<TEntity>(TEntity entity) where TEntity : BaseEntity;
        void AddRange<TEntity>(List<TEntity> entities) where TEntity : BaseEntity;
        void Update<TEntity>(TEntity entity) where TEntity : BaseEntity;
        void Delete<TEntity>(TEntity entity) where TEntity : BaseEntity;
        Task<int> SaveAsync();
    }
}
