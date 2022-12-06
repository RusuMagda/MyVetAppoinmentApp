using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVetAppoinment.Shared.Domain
{
    public class Client
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<Pet> Pets { get; set; }

        public string EMail { get; set; }

        public string PhoneNumber { get; set; }
    }
}
