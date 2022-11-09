using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVetAppoinment.Entities
{
    public class Shop
    { 
        public string ShopId { get; set; }
        public string ShopName { get; set; }    
        public List<Drug> Drugs { get; set; }
    }
}
