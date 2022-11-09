using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVetAppoinment.Entities
{
    public class Drug
    {
         public string DrugName { get; set; }

         public string DrugDescription { get; set; }

         public int Stock { get; set; }

         public int ID { get; set; }
        public int Price { get; set; }
    }
}
