using MyVetAppoinment.Shared.Domain;

namespace MyVetAppoinment.UI.Pages.Services
{
    public interface IPetDataService
    {
        Task<IEnumerable<Pet>?> GetAllPets();
        Task<IEnumerable<Pet>?> GetPetsClient(Guid id);

        Task<Pet?> GetPetDetail(Guid petId);
        Task<Pet?> GetPetId(Guid id, String name );


        void AddPet(Pet pet);
        void EditPet(Guid petId, Pet pet);
        void DeletePet(Guid petId);
    }
}
