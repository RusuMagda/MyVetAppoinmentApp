using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string DrugName { get; set; }

        public string DrugDescription { get; set; }

        public int Stock { get; set; } //nr bucati

        public int ID { get; set; }

        public int Price { get; set; }

        public string SaleForm { get; set; } //unguent, pastile, lichid

        public int Quantity { get; set; } //cantitate per bucata

        public string QuantityMeasure { get; set; } //mg, nr pastile, ml
    }
}
