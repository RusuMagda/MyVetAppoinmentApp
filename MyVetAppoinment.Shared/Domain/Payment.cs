using System.ComponentModel.DataAnnotations;

namespace MyVetAppoinment.Shared.Domain
{
    public class Payment
    {
        [Required]
        [RegularExpression("^[A-Za-z ,.'-]+$", ErrorMessage = "Wrong Format")]
        public string FirstName { get; set; } = string.Empty;
        [RegularExpression("^[A-Za-z ,.'-]+$", ErrorMessage = "Wrong Format")]
        public string LastName { get; set; } = string.Empty;
        
        [RegularExpression("^4[0-9]{12}(?:[0-9]{3})?$", ErrorMessage = "Wrong Format")]
        public string CardNumber { get; set; } = string.Empty;

        [RegularExpression("^[0-9]{3,4}$", ErrorMessage = "Wrong Format")]
        public string CVC { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public int Month { get; set; }

        public int Year { get; set; }
    }
}