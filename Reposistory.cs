using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleCalci
{
    public class Reposistory
    {
        public record class Repository(
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("operand1")] decimal Operand1,
        [property: JsonPropertyName("operand2")] decimal Operand2,
        [property: JsonPropertyName("symbol")] char Symbol,
        [property: JsonPropertyName("Result")] decimal Result
        );
    }
}
