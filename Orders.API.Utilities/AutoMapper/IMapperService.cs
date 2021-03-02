using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.API.Utilities.AutoMapper
{
    public interface IMapperService
    {
        TDestination Map<TSource, TDestination>(TSource sourceObj);
        void Map<TSource, TDestination>(TSource sourceObj, TDestination destObj);
        List<string> MapFields<TSource, TDestination>(List<string> fieldsNames);
    }
}
