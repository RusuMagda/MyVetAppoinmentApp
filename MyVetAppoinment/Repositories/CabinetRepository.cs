namespace MyVetAppoinment.Repositories
{
    public class CabinetRepository : ICabinetRepository
    {
        private readonly MyVetAppointmentDatabaseContext context;
        public CabinetRepository(MyVetAppointmentDatabaseContext context)
        {
            this.context = context;
        }

        public void Add(Cabinet cabinet)
        {
            this.context.Cabinets.Add(cabinet);
            this.context.SaveChanges();
        }

        public void Update(Cabinet cabinet)
        {
            this.context.Cabinets.Update(cabinet);
            this.context.SaveChanges();
        }

        public void Delete(Cabinet cabinet)
        {
            this.context.Cabinets.Remove(cabinet);
            this.context.SaveChanges();
        }
    }
}
