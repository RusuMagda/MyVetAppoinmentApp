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

        public int ShopId { get; set; }
        public string ShopName { get; set; }    
        public List<Drug> Drugs { get; set; }
    }
}