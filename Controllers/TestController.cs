using Calculator.Model;
using Calculator.Services;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    public class TestController : Controller
    {
        private readonly ICalciService calciService;

        public TestController(ICalciService calciService)
        {
            this.calciService = calciService;
        }


        [HttpPost("AddCalculation/{a}/{b}")]
        public double AddNumbers(double a, double b)
        {
            return calciService.Add(a, b);
        }

        [HttpPost("SubtractCalculation/{a}/{b}")]
        public double SubtractNumbers(double a, double b)
        {
            return calciService.Substract(a, b);
        }

        [HttpPost("MultiplyCalculation/{a}/{b}")]
        public double MultiplyNumbers(double a, double b)
        {
            return calciService.Multiply(a, b);
        }

        [HttpPost("DivideCalculation/{a}/{b}")]
        public double DivideNumbers(double a, double b)
        {
            return calciService.Divide(a, b);
        }
    }
}
