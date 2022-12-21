namespace MyVetAppoinment.Shared.Domain
{
    public class Pet
    {
        public Guid Id { get; set; } = Guid.Empty;
        public Guid OwnerId { get; set; } = Guid.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; } = default(DateTime);
    }
}
