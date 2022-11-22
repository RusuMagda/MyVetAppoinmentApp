using MyVetAppoinment.Domain.Entities;

namespace MyVetAppoinment.Repositories
{
    public interface ICabinetRepository
    {
        void Add(Cabinet cabinet);
        void Delete(Cabinet cabinet);
        Cabinet Get(Guid id);
        List<Cabinet> GetAll();
        void Save();
        void Update(Cabinet cabinet);
    }
}