using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Calculator.Services
{
    public class CalciService : ICalciService
    {

        public double Add(double a, double b)
        {
            return a+b;
        }

        public double Substract(double a, double b)
        {
            return a-b;
        }

        public double Multiply(double a, double b)
        {
            return a*b;
        }

        public double Divide(double a, double b)
        {
            if (b == 0) throw new Exception("Dont divide with zero");
            return a/b;
        }
    }
}
