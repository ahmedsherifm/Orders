﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orders.API.DAL.Interfaces;
using Orders.API.Entities.Models;
using Orders.API.Services.Interfaces;

namespace Orders.API.Services.Services
{
    public class LocationService: BaseService, ILocationService
    {
        public LocationService(IGenericRepository genericRepository) : base(genericRepository)
        {
        }

        public async Task<List<Location>> GetLocationsByOrderId(Guid orderId)
        {
            var order = await GetById<Order>(orderId, "Locations");
            return order.Locations.ToList();
        }

        public async Task AddLocation(Location location)
        {
            GenericRepository.Add(location);
            await GenericRepository.SaveAsync();
        }
    }
}
