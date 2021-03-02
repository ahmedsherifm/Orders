using System;
using System.Collections.Generic;
using System.Text;
using Orders.API.Entities.Models;

namespace Orders.API.DAL.Interfaces
{
    public interface IRecordSubjectRepository
    {
        RecordSubject GetRecordSubjectById(Guid id);
        void AddRecordSubject(RecordSubject recordSubject);
    }
}
