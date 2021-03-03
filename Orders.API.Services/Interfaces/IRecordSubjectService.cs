using System;
using System.Threading.Tasks;
using Orders.API.Models;

namespace Orders.API.Services.Interfaces
{
    public interface IRecordSubjectService
    {
        Task<RecordSubjectModel> GetRecordSubjectById(Guid id);
    }
}
