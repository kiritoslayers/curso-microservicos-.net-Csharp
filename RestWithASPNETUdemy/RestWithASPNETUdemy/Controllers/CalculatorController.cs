using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secoundNumber}")]
        public IActionResult GetSum(string firstNumber, string secoundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secoundNumber))
            {
                double sum = ConvertNumber(firstNumber) + ConvertNumber(secoundNumber);
                return Ok(sum.ToString());
            }
            else
            {
                return BadRequest("Invalid input");
            }
        }

        [HttpGet("sub/{firstNumber}/{secoundNumber}")]
        public IActionResult GetSub(string firstNumber, string secoundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secoundNumber))
            {
                double sub = ConvertNumber(firstNumber) - ConvertNumber(secoundNumber);
                return Ok(sub.ToString());
            }
            else
            {
                return BadRequest("Invalid input");
            }
        }

        [HttpGet("mul/{firstNumber}/{secoundNumber}")]
        public IActionResult GetMul(string firstNumber, string secoundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secoundNumber))
            {
                double mul = ConvertNumber(firstNumber) * ConvertNumber(secoundNumber);
                return Ok(mul.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("div/{firstNumber}/{secoundNumber}")]
        public IActionResult GetDiv(string firstNumber, string secoundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secoundNumber))
            {
                double div = ConvertNumber(firstNumber) / ConvertNumber(secoundNumber);
                return Ok(div.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("med/{firstNumber}/{secoundNumber}")]
        public IActionResult GetMed(string firstNumber, string secoundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secoundNumber))
            {
                double med = (ConvertNumber(firstNumber) + ConvertNumber(secoundNumber)) / 2;
                return Ok(med.ToString());
            }
            else
            {
                return BadRequest("Invalid input");
            }
        }



        [HttpGet("square/{firstNumber}")]
        public IActionResult GetSquare(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                double div = Math.Sqrt(ConvertNumber(firstNumber));
                return Ok(div.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private bool IsNumeric(string stringNumber)
        {
            bool isNumber = double.TryParse(stringNumber, out double number);
            return isNumber;
        }

        private Double ConvertNumber(string stringNumber)
        {
            try
            {
                return double.Parse(stringNumber);
            }
            catch
            {
                return 0;
            }
        }
    }
}