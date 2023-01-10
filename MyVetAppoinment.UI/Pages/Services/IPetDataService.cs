using MyVetAppoinment.Shared.Domain;

namespace MyVetAppoinment.UI.Pages.Services
{
    public interface IPetDataService
    {
        void AddPet(Pet pet);
        void DeletePet(Guid petId);
        void EditPet(Guid petId, Pet pet);
        Task<IEnumerable<Appointment>?> GetAllAppointments(Guid petId);
        Task<IEnumerable<Pet>?> GetAllPets();
        Task<Pet?> GetPetDetail(Guid petId);
        Task<Pet?> GetPetId(Guid id, string name);
        Task<IEnumerable<Pet>?> GetPetsClient(Guid id);
    }
}