using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Orders.API.DAL.Interfaces;
using Orders.API.Entities.Models;
using Orders.API.Models;
using Orders.API.Services.Interfaces;
using Orders.API.Utilities.AutoMapper;

namespace Orders.API.Services.Services
{
    public class RecordSubjectService: BaseService, IRecordSubjectService
    {
        public RecordSubjectService(IGenericRepository genericRepository, IMapperService mapperService) : base(genericRepository, mapperService)
        {
        }

        public RecordSubjectService(IMapperService mapperService) : base(mapperService)
        {
        }

        public async Task<RecordSubjectModel> GetRecordSubjectById(Guid id)
        {
            return await GetById<RecordSubject, RecordSubjectModel>(id, "Order");
        }

        public async Task AddRecordSubject(RecordSubjectModel recordSubjectModel)
        {
            var recordSubject = MapperService.Map<RecordSubjectModel, RecordSubject>(recordSubjectModel);
            GenericRepository.Add(recordSubject);
            await GenericRepository.SaveAsync();
        }
    }
}
