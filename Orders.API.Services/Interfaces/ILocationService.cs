using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Orders.API.Models;

namespace Orders.API.Services.Interfaces
{
    public interface ILocationService
    {
        Task<List<LocationModel>> GetLocationsByOrderId(Guid orderId);
        Task AddLocation(LocationModel locationModel);
    }
}
