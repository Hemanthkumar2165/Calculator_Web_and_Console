using Azure.Core;
using Calculator.Context;
using Calculator.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcisController : ControllerBase
    {
        private readonly ContextData context;

        public CalcisController(ContextData context)
        {
            this.context = context;
        }

        //For All Records
        [HttpGet("AllRecords")]
        public async Task<ActionResult<IEnumerable<Calci>>> Getcalculations()
        {
            return await context.calculations.ToListAsync();
        }

        //For Specific Id
        [HttpGet("{id}")]                   
        public Calci GetCalci(int id)
        {
            var calci = context.calculations.FirstOrDefault(c => c.Id == id );

            return calci;
        }


        // Post a record to table
        [HttpPost("AddCalculation")]
        public IActionResult PostCalci([FromBody] Calci request)
        {
            decimal result;

            switch (request.Symbol)
            {
                case '+':
                    result = request.Operand1 + request.Operand2;
                    break;
                case '-':
                    result = request.Operand1 - request.Operand2;
                    break;
                case '*':
                    result = request.Operand1 * request.Operand2;
                    break;
                case '/':
                    if (request.Operand2 == 0)
                        return BadRequest("Division by zero.");
                    result = request.Operand1 / request.Operand2;
                    break;
                default:
                    return BadRequest("Invalid symbol. Use +, -, *, or /");
            }
            request.Result = result;

            context.calculations.Add(request);
            context.SaveChanges();

            return Ok(result);
        }

        // Delete Specific Record
        [HttpDelete("{id}")]
        public string DeleteCalci(int id)
        {
            var calci =  context.calculations.FirstOrDefault(c => c.Id == id);

            if (calci == null)
            {
                return $"Not found any record with that id:{id}";
            }

            context.calculations.Remove(calci);
            context.SaveChangesAsync();

            return $"Deleted record with id:{id}";
        }



        //For my forntend

        [HttpPost("forntend/{op1}/{op2}/{symbol}")]
        public decimal ForntEndResult(decimal op1, decimal op2, string symbol )
        {
            decimal result;

            switch (symbol.ElementAt(0))
            {
                case '+':
                    result = op1 + op2;
                    break;
                case '-':
                    result = op1 - op2;
                    break;
                case '*':
                    result = op1 * op2;
                    break;
                case '/':
                    if (op2 == 0)
                        return 0;
                    result = op1/op2;
                    break;
                default:
                    return 0;
            }
            Calci request = new() {Operand1=op1, Operand2=op2, Symbol= symbol.ElementAt(0), Result = result };
            request.Result = result;
            context.calculations.Add(request);
            context.SaveChanges();

            return result;
        }

    }
}
