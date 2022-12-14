namespace MyVetAppoinment.Shared.Domain
{
    public class Drug
    {
        public string DrugName { get; set; } = string.Empty;

        public string DrugDescription { get; set; } = string.Empty;

        public int Stock { get; set; } = default(int);

        public Guid ID { get; set; } = Guid.Empty;

        public int Price { get; set; } = default(int);

        public string SaleForm { get; set; } = string.Empty; 
        public int Quantity { get; set; } = default(int); 

        public string QuantityMeasure { get; set; } = string.Empty;
    }
}
