namespace MyVetAppoinment.Domain.Entities
{
    public class Shop
    {
        public Shop(string shopName,Guid cabinetId)
        {
            ShopId = Guid.NewGuid();
            ShopName = shopName;
            CabinetId = cabinetId;
        }

        public Guid ShopId { get;  set; }
        public string ShopName { get;  set; }  
        public Guid CabinetId { get;  set; }
        public List<Drug> Drugs { get;  set; }= new List<Drug>();

        public void AttachShopToCabinet(Cabinet cabinet)
        {
            CabinetId = cabinet.Id;
        }
       
        public void addDrug(Drug drug)
        {
            Drugs.Add(drug);
        }
    }
}