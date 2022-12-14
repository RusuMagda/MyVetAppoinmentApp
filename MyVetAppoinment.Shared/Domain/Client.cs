namespace MyVetAppoinment.Shared.Domain
{
    public class Client
    {
        public Guid Id { get; set; } = Guid.Empty;

        public string Name { get; set; } = string.Empty;

        public List<Pet> Pets { get; set; } = new List<Pet>();

        public string EMail { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;
    }
}
