namespace MyVetAppoinment.Domain.Entities
{
    public class Drug
    {
        public Drug(string drugName, string drugDescription, int stock, int price, string saleForm, int quantity, string quantityMeasure)
        {
            DrugName = drugName;
            DrugDescription = drugDescription;
            Stock = stock;
            ID = Guid.NewGuid();
            Price = price;
            SaleForm = saleForm;
            Quantity = quantity;
            QuantityMeasure = quantityMeasure;
        }

        public string DrugName { get; private set; }

        public string DrugDescription { get; private set; }

        public int Stock { get; private set; } //nr bucati

        public Guid ID { get; private set; }

        public int Price { get; private set; }

        public string SaleForm { get; private set; } //unguent, pastile, lichid

        public int Quantity { get; private set; } //cantitate per bucata

        public string QuantityMeasure { get; private set; } //mg, nr pastile, ml
    }
}
