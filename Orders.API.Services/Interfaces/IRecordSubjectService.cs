using System;
using System.Threading.Tasks;
using Orders.API.Entities.Models;

namespace Orders.API.Services.Interfaces
{
    public interface IRecordSubjectService
    {
        Task<RecordSubject> GetRecordSubjectById(Guid id);
    }
}
