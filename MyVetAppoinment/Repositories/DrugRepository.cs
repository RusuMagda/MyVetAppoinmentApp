using MyVetAppoinment.Data;
using MyVetAppoinment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVetAppoinment.Repositories
{
    public class DrugRepository : IDrugRepository
    {
        private readonly MyVetAppointmentDatabaseContext context;

        public DrugRepository(MyVetAppointmentDatabaseContext context)
        {
            this.context = context;
        }

        public void Add(Drug drug)
        {
            this.context.Drugs.Add(drug);
            this.context.SaveChanges();
        }

        public void Update(Drug drug)
        {
            this.context.Drugs.Update(drug);
            this.context.SaveChanges();
        }

        public void Delete(Drug drug)
        {
            this.context.Drugs.Remove(drug);
            this.context.SaveChanges();
        }
    }
}
