using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Orders.API.DAL.Interfaces;
using Orders.API.Entities.Models;
using Orders.API.Services.Interfaces;

namespace Orders.API.Services.Services
{
    public class RecordSubjectService: BaseService, IRecordSubjectService
    {
        public RecordSubjectService(IGenericRepository genericRepository) : base(genericRepository)
        {
        }

        public async Task<RecordSubject> GetRecordSubjectById(Guid id)
        {
            return await GetById<RecordSubject>(id, "Order");
        }

        public async Task AddRecordSubject(RecordSubject recordSubject)
        {
            GenericRepository.Add(recordSubject);
            await GenericRepository.SaveAsync();
        }
    }
}
