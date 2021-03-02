using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orders.API.DAL.Interfaces;
using Orders.API.Entities.Models;

namespace Orders.API.DAL.Repositories
{
    public class RecordSubjectRepository : IRecordSubjectRepository
    {
        private readonly OrdersContext _ordersContext;

        public RecordSubjectRepository(OrdersContext ordersContext)
        {
            _ordersContext = ordersContext;
        }

        public RecordSubject GetRecordSubjectById(Guid id)
        {
            return _ordersContext.RecordSubjects.FirstOrDefault(r => r.Id == id);
        }

        public void AddRecordSubject(RecordSubject recordSubject)
        {
            _ordersContext.RecordSubjects.Add(recordSubject);
            _ordersContext.SaveChanges();
        }
    }
}
