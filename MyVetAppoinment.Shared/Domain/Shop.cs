namespace MyVetAppoinment.Shared.Domain
{
    public class Shop
    {
        public Guid ShopId { get; set; } = Guid.Empty;
        public string ShopName { get; set; } = string.Empty;
        public Guid CabinetId { get; set; } = Guid.Empty;
        public List<Drug> Drugs { get; set; } = new List<Drug>();
    }
}
