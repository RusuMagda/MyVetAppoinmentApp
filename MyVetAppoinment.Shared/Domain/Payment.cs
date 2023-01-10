namespace MyVetAppoinment.Shared.Domain
{
    public class Payment
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string CardNumber { get; set; } = string.Empty;

        public string CVC { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public int Month { get; set; }

        public int Year { get; set; }
    }
}