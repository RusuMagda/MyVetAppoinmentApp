using MyVetAppoinment.Shared.Domain;

namespace MyVetAppoinment.UI.Pages.Services
{
    public interface IClientDataService
    {
        Task<IEnumerable<Client>?> GetAllClients();

        Task<Client?> GetClientDetail(Guid clientId);
        Task<Client?> GetClientEmail(String email);

        void AddClient(Client client);
        void EditClient(Guid clientId, Client client);
        void DeleteClient(Guid clientId);
    }
}
