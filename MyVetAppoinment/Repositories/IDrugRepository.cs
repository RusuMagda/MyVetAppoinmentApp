namespace MyVetAppoinment.Repositories
{
    public interface IDrugRepository
    {
        void Add(Drug drug);
        void Delete(Drug drug);
        void Update(Drug drug);
    }
}