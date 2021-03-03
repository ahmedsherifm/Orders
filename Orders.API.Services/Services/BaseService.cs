using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Orders.API.DAL.Interfaces;
using Orders.API.Entities.Models;

namespace Orders.API.Services.Services
{
    public class BaseService
    {
        protected IGenericRepository GenericRepository { get; }

        public BaseService(IGenericRepository genericRepository)
        {
            GenericRepository = genericRepository;
        }

        protected async Task<List<TEntity>> GetAll<TEntity>(Expression<Func<TEntity, bool>> filter, string includeProperties = "")
            where TEntity : BaseEntity
        {

            return await GenericRepository.GetListAsync(filter, includeProperties);
        }

        protected async Task<List<TEntity>> GetAll<TEntity>(string includeProperties = "") where TEntity : BaseEntity
        {

            return await GenericRepository.GetListAsync<TEntity>(t => !t.Deleted, includeProperties);
        }

        protected async Task<TEntity> GetById<TEntity>(Guid id, string includeProperties = "") where TEntity : BaseEntity
        {
            return await GenericRepository.GetByIdAsync<TEntity>(id, includeProperties);
        }
    }
}
