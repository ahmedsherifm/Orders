using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Orders.API.Entities.Models;

namespace Orders.API.Services.Interfaces
{
    public interface ILocationService
    {
        Task<List<Location>> GetLocationsByOrderId(Guid orderId);
        Task AddLocations(IEnumerable<Location> locationModels);
    }
}
