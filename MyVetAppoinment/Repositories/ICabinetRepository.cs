using MyVetAppoinment.Entities;

namespace MyVetAppoinment.Repositories
{
    public interface ICabinetRepository
    {
        void Add(Cabinet cabinet);
        void Delete(Cabinet cabinet);
        void Update(Cabinet cabinet);
    }
}