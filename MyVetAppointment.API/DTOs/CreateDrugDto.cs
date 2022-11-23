namespace MyVetAppointment.API.DTOs
{
    public class CreateDrugDto
    {
        public string DrugName { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public string SaleForm { get; set; }
        public int Quantity { get; set; }
        public string QuantityMeasure { get; set; }
    }
}
