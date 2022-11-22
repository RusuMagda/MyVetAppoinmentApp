namespace MyVetAppoinment.Domain.Entities
{
    public class Shop
    {
        public Shop(string shopName)
        {
            ShopId = Guid.NewGuid();
            ShopName = shopName;
        }

        public Guid ShopId { get; private set; }
        public string ShopName { get; private set; }    
        public List<Drug> Drugs { get; private set; }

        public void addDrug(Drug drug)
        {
            Drugs.Add(drug);
        }
    }
}