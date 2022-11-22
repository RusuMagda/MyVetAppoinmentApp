namespace MyVetAppoinment.Repositories
{
    public interface IClientRepository
    {
        void Add(Client client);
        void Delete(Client client);
        void Update(Client client);
    }
}