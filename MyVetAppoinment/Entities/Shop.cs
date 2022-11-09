namespace MyVetAppoinment.Entities
{
    public class Shop
    {
        public Shop(int shopId, string shopName, List<Drug> drugs)
        {
            ShopId = shopId;
            ShopName = shopName;
            Drugs = drugs;
        }

        public int ShopId { get; }
        public string ShopName { get; }    
        public List<Drug> Drugs { get; }
    }
}