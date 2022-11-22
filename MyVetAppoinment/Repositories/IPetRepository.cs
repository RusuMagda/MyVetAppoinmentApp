namespace MyVetAppoinment.Repositories
{
    public interface IPetRepository
    {
        void Add(Pet pet);
        void Delete(Pet pet);
        void Update(Pet pet);
    }
}