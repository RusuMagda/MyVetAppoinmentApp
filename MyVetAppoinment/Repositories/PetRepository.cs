namespace MyVetAppoinment.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly MyVetAppointmentDatabaseContext context;

        public PetRepository(MyVetAppointmentDatabaseContext context)
        {
            this.context = context;
        }

        public void Add(Pet pet)
        {
            this.context.Pets.Add(pet);
            this.context.SaveChanges();
        }

        public void Update(Pet pet)
        {
            this.context.Pets.Update(pet);
            this.context.SaveChanges();
        }

        public void Delete(Pet pet)
        {
            this.context.Pets.Remove(pet);
            this.context.SaveChanges();
        }
    }
}
