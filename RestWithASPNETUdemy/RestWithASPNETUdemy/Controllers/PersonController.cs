using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public PersonController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        //[HttpGet("GetPerson/{firstNumber}/{secoundNumber}")]
        //public IActionResult GetPerson(string firstNumber, string secoundNumber)
        //{
        //    return Ok();
        //}


    }
}