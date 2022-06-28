using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NumberManagmentAPI.DTO;
using NumberManagmentAPI.Service;

namespace NumberManagmentAPI.Controllers
{
    [Route("api/number-operation")]
    public class NumberOperationController : Controller
    {
        private readonly INumberOperationService _service;
        private readonly ILogger<NumberOperationController> _logger;

        public NumberOperationController(
            ILogger<NumberOperationController> logger,
            INumberOperationService service)
        {
            _service = service;
            _logger = logger;
        }

        [Route("")]
        [HttpPost]
        public ActionResult ActiveNumber([FromBody] ActiveNumberInDTO input)
        {
            //if (obj == null)
            //    return BadRequest();

            _service.ActiveNumber(input);

            return Ok("Number Active with successfully");
        }

   }
}