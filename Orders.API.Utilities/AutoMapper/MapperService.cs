using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace Orders.API.Utilities.AutoMapper
{
    public class MapperService: IMapperService
    {
        private readonly IMapper _mapper;

        public MapperService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDestination Map<TSource, TDestination>(TSource sourceObj)
        {
            return _mapper.Map<TDestination>(sourceObj);
        }

        public void Map<TSource, TDestination>(TSource sourceObj, TDestination destObj)
        {
            _mapper.Map<TSource, TDestination>(sourceObj, destObj);
        }

        // source is the DB Entity
        // destination is the DTO
        // should map from DTO name to DB Entity Name
        public List<string> MapFields<TSource, TDestination>(List<string> destinationFieldNames)
        {
            var mappedFields = new List<string>();

            var configs = _mapper.ConfigurationProvider.FindTypeMapFor(typeof(TSource), typeof(TDestination));
            if (configs != null)
            {
                mappedFields.AddRange(destinationFieldNames.Select(destField => configs.PropertyMaps.FirstOrDefault(p => string.Equals(p.DestinationName, destField, StringComparison.CurrentCultureIgnoreCase))).Select(fieldMap => fieldMap?.SourceMember.Name ?? ""));
            }
            return mappedFields;
        }
    }
}
