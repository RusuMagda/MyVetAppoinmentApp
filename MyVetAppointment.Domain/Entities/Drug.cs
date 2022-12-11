namespace MyVetAppoinment.Domain.Entities
{
    public class Drug
    {
        public Drug(string drugName, string drugDescription, int stock, int price, string saleForm, int quantity, string quantityMeasure)
        {
            DrugName = drugName;
            DrugDescription = drugDescription;
            Stock = stock;
            Id = Guid.NewGuid();
            Price = price;
            SaleForm = saleForm;
            Quantity = quantity;
            QuantityMeasure = quantityMeasure;
        }
        public Drug(Guid id,string drugName, string drugDescription, int stock, int price, string saleForm, int quantity, string quantityMeasure)
        {
            DrugName = drugName;
            DrugDescription = drugDescription;
            Stock = stock;
            Id = id;
            Price = price;
            SaleForm = saleForm;
            Quantity = quantity;
            QuantityMeasure = quantityMeasure;
        }

        public string DrugName { get; set; } = string.Empty;

        public string DrugDescription { get; set; } = string.Empty;

        public int Stock { get; set; } = 0;

        public Guid Id { get;  set; } = Guid.Empty;

        public int Price { get; set; } = default(int);

        public string SaleForm { get; set; } = string.Empty;

        public int Quantity { get; set; } = default(int);

        public string QuantityMeasure { get; set; } = string.Empty;
    }
}
