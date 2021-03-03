using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Orders.API.Core;
using Orders.API.Entities.Models;
using Orders.API.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Orders.API.Controllers
{
    public class Test
    {
        public string Str { get; set; }
        public DateTime Date { get; set; }
        public RecordTypes RecordType { get; set; }
        public RecordSubject RecordSubject { get; set; }
    }


    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        private readonly ILocationService _locationService;

        private readonly IRecordSubjectService _recordSubjectService;

        public OrderController(IOrderService orderService, ILocationService locationService,
            IRecordSubjectService recordSubjectService)
        {
            _orderService = orderService;
            _locationService = locationService;
            _recordSubjectService = recordSubjectService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Order order)
        {
            try
            {
                await _recordSubjectService.AddRecordSubject(order.RecordSubject);
                await _locationService.AddLocations(order.Locations);
                await _orderService.AddNewOrder(order);

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500);
            }
        }

        //// POST api/<controller>
        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody]Test test)
        //{
        //    try
        //    {
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        return StatusCode(500);
        //    }
        //}
    }
}
