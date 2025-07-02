using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.Model
{
    [Table("Calculator")]
    public class Calci
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public decimal Operand1 { get; set; }

        public decimal Operand2 { get; set; }

        public char Symbol { get; set; }

        public decimal Result { get; set; }
    }
}
