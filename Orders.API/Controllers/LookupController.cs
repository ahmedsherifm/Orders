using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Orders.API.Core;
using Orders.API.Utilities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Orders.API.Controllers
{
    [Route("api/[controller]")]
    public class LookupController : Controller
    {
        // GET: /<controller>/caseTypes
        [HttpGet("caseTypes")]
        public IActionResult GetCaseTypes()
        {
            var caseTypesStrings = EnumUtils<CaseTypes>.GetAllEnumDescriptionList();
            return Ok(caseTypesStrings);
        }

        // GET: /<controller>/caseTypes
        [HttpGet("recordTypes")]
        public IActionResult GetRecordTypes()
        {
            var recordTypesStrings = EnumUtils<RecordTypes>.GetAllEnumDescriptionList();
            return Ok(recordTypesStrings);
        }
    }
}
