using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Orders.API.DAL.Interfaces;
using Orders.API.Entities.Models;
using Orders.API.Models;
using Orders.API.Utilities.AutoMapper;

namespace Orders.API.Services.Services
{
    public class BaseService
    {
        protected IMapperService MapperService { get; }
        protected IGenericRepository GenericRepository { get; }

        public BaseService(IGenericRepository genericRepository, IMapperService mapperService)
        {
            GenericRepository = genericRepository;
            MapperService = mapperService;
        }

        public BaseService(IMapperService mapperService)
        {
            MapperService = mapperService;
        }

        protected async Task<List<TModel>> GetAll<TEntity, TModel>(Expression<Func<TEntity, bool>> filter, string includeProperties = "")
            where TEntity : BaseEntity
        {

            var list = await GenericRepository.GetListAsync(filter, includeProperties);
            return MapperService.Map<List<TEntity>, List<TModel>>(list);
        }

        protected async Task<List<TModel>> GetAll<TEntity, TModel>(string includeProperties) where TEntity : BaseEntity
        {
            var list = await GenericRepository.GetListAsync<TEntity>((t => !t.Deleted), includeProperties);
            return MapperService.Map<List<TEntity>, List<TModel>>(list);
        }

        protected async Task<TModel> GetById<TEntity, TModel>(Guid id, string includeProperties) where TEntity : BaseEntity
        {
            var entity = await GenericRepository.GetByIdAsync<TEntity>(id, includeProperties);
            return MapperService.Map<TEntity, TModel>(entity);
        }
    }
}
