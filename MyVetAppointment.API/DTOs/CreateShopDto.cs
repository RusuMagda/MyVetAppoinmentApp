namespace MyVetAppointment.API.DTOs
{
    public class CreateShopDto
    {
        public string ShopName { get; set; } = string.Empty;
        public Guid CabinetId { get; set; } = Guid.Empty;
    }
}