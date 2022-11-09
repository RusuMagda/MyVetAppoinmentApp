using MyVetAppoinment.Data;
using MyVetAppoinment.Entities;

namespace MyVetAppoinment.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly MyVetAppointmentDatabaseContext context;

        public ClientRepository(MyVetAppointmentDatabaseContext context)
        {
            this.context = context;
        }

        public void Add(Client client)
        {
            this.context.Clients.Add(client);
            this.context.SaveChanges();
        }

        public void Update(Client client)
        {
            this.context.Clients.Update(client);
            this.context.SaveChanges();
        }

        public void Delete(Client client)
        {
            this.context.Clients.Remove(client);
            this.context.SaveChanges();
        }
    }
}
