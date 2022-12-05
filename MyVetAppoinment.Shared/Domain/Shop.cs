using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVetAppoinment.Shared.Domain
{
    public class Shop
    {
        public Guid ShopId { get; set; }
        public string ShopName { get; set; }
        public Guid CabinetId { get; set; }
        public List<Drug> Drugs { get; set; }
    }
}
