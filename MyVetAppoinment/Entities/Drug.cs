namespace MyVetAppoinment.Entities
{
    public class Drug
    {
        public Drug(string drugName, string drugDescription, int stock, int iD, int price, string saleForm, int quantity, string quantityMeasure)
        {
            DrugName = drugName;
            DrugDescription = drugDescription;
            Stock = stock;
            ID = iD;
            Price = price;
            SaleForm = saleForm;
            Quantity = quantity;
            QuantityMeasure = quantityMeasure;
        }

        public string DrugName { get; }

        public string DrugDescription { get; }

        public int Stock { get; } //nr bucati

        public int ID { get; }

        public int Price { get; }

        public string SaleForm { get; } //unguent, pastile, lichid

        public int Quantity { get; } //cantitate per bucata

        public string QuantityMeasure { get; } //mg, nr pastile, ml
    }
}
