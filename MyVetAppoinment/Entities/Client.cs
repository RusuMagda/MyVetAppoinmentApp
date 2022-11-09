using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVetAppoinment.Entities
{
    public class Client
    {
        public int Id { get; set; } 

        public string Name { get; set; }    

        public List<Pet> Pets { get; set; }

        public string EMail { get; set; }

        public int PhoneNumber { get; set; }
    }
}
