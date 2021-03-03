using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orders.API.DAL.Interfaces;
using Orders.API.Entities.Models;
using Orders.API.Models;
using Orders.API.Services.Interfaces;
using Orders.API.Utilities.AutoMapper;

namespace Orders.API.Services.Services
{
    public class LocationService: BaseService, ILocationService
    {
        public LocationService(IGenericRepository genericRepository, IMapperService mapperService) : base(genericRepository, mapperService)
        {
        }

        public LocationService(IMapperService mapperService) : base(mapperService)
        {
        }

        public async Task<List<LocationModel>> GetLocationsByOrderId(Guid orderId)
        {
            var order = await GetById<Order, OrderModel>(orderId);
            return order.Locations.ToList();
        }

        public async Task AddLocations(List<LocationModel> locationModels)
        {
            var locations = MapperService.Map<List<LocationModel>, List<Location>>(locationModels);
            GenericRepository.AddRange(locations);
            await GenericRepository.SaveAsync();
        }
    }
}
