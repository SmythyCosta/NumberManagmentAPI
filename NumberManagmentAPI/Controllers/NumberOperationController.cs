using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using NumberManagmentAPI.DTO;
using NumberManagmentAPI.Service;

namespace NumberManagmentAPI.Controllers
{
    [ApiController]
    public class NumberOperationController : ControllerBase
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


        [Route("/number-operation/active")]
        [HttpPost]
        public ActionResult ActiveNumber([FromBody] ActiveNumberInDTO input)
        {
            _service.ActiveNumber(input);
            return Ok("Number Active with successfully");
        }
        

        [Route("/number-operation/cancel")]
        [HttpPost]
        public ActionResult CancelNumber([FromBody] ActiveNumberInDTO input)
        {
            _service.CancelNumber(input);
            return Ok("Number Active with successfully");
        }

        [Route("/number-operation/list/{status}")]
        [HttpGet]
        public async Task<IActionResult> Get(int status)
        {
            try
            {
                var numbers = await _service.GetAllNubersByStatus(status);

                return Ok(numbers);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }


    }
}