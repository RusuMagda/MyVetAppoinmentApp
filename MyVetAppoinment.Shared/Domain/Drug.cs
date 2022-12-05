using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVetAppoinment.Shared.Domain
{
    public class Drug
    {
        public string DrugName { get; set; }

        public string DrugDescription { get; set; }

        public int Stock { get; set; } 

        public Guid ID { get; set; }

        public int Price { get; set; }

        public string SaleForm { get; set; } 
        public int Quantity { get; set; } 

        public string QuantityMeasure { get; set; }
    }
}
