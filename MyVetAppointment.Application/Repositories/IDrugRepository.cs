using MyVetAppoinment.Domain.Entities;

namespace MyVetAppoinment.Repositories
{
    public interface IDrugRepository
    {
        void Add(Drug drug);
        void Delete(Drug drug);
        Drug Get(Guid id);
        List<Drug> GetAll();
        void Save();
        void Update(Drug drug);
    }
}