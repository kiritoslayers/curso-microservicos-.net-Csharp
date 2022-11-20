using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Calculadora.Controllers
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

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult GetSum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                decimal sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid input");
        }


        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult GetSub(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                decimal sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sub.ToString());
            }

            return BadRequest("Invalid input");
        }


        [HttpGet("mult/{firstNumber}/{secoundNumber}")]
        public IActionResult GetMult(string firstNumber, string secoundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secoundNumber))
            {
                decimal mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secoundNumber);
                return Ok(mult.ToString());
            }

            return BadRequest("Invalid input");
        }


        [HttpGet("div/{firstNumber}/{secoundNumber}")]
        public IActionResult GetDiv(string firstNumber, string secoundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secoundNumber))
            {
                decimal div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secoundNumber);
                return Ok(div.ToString());
            }

            return BadRequest("Invalid input");
        }


        [HttpGet("med/{n1}/{n2}")]
        public IActionResult GetMed(string n1, string n2)
        {
            if (IsNumeric(n1) && IsNumeric(n2))
            {
                decimal sum = ConvertToDecimal(n1) + ConvertToDecimal(n2);
                decimal result = sum / 2;
                return Ok(result.ToString());
            }

            return BadRequest("Invalid input");
        }


        [HttpGet("raiz/{n1}")]
        public IActionResult GetRaiz(string n1)
        {
            if (IsNumeric(n1))
            {
                decimal convert = ConvertToDecimal(n1);
                double convertToDouble = Convert.ToDouble(convert);

                var result = Math.Sqrt(convertToDouble);
                return Ok(result.ToString());
            }

            return BadRequest("Invalid input");
        }

        private bool IsNumeric(string strNumber)
        {
            double number;

            // esse método de conversão não conhecia
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, out number);

            return isNumber;
        }

        private decimal ConvertToDecimal(string number)
        {
            decimal decimalValue;
            if (decimal.TryParse(number, out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }

    }
}
