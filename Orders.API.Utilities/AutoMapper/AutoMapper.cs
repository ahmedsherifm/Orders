using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Orders.API.Entities.Models;
using Orders.API.Models;

namespace Orders.API.Utilities.AutoMapper
{
    public class OrdersProfile: Profile
    {
        public OrdersProfile()
        {
            CreateMap<Order, OrderModel>().ReverseMap();
            CreateMap<Location, LocationModel>().ReverseMap();
            CreateMap<RecordSubject, RecordSubjectModel>().ReverseMap();
        }
    }
}
