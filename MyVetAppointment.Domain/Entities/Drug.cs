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
        public Drug(Guid id,string drugName, string drugDescription, int stock, int price, string saleForm, int quantity, string quantityMeasure)
        {
            DrugName = drugName;
            DrugDescription = drugDescription;
            Stock = stock;
            ID = id;
            Price = price;
            SaleForm = saleForm;
            Quantity = quantity;
            QuantityMeasure = quantityMeasure;
        }

        public string DrugName { get;  set; }

        public string DrugDescription { get;  set; }

        public int Stock { get;  set; } //nr bucati

        public Guid ID { get;  set; }

        public int Price { get;  set; }

        public string SaleForm { get;  set; } //unguent, pastile, lichid

        public int Quantity { get;  set; } //cantitate per bucata

        public string QuantityMeasure { get;  set; } //mg, nr pastile, ml
    }
}
