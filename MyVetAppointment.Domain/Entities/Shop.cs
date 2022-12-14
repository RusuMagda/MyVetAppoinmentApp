namespace MyVetAppoinment.Domain.Entities
{
    public class Shop
    {
        public Shop(Guid shopId, string shopName, Guid cabinetId)
        {
            ShopId = shopId;
            ShopName = shopName;
            CabinetId = cabinetId;
        }

        public Shop(string shopName,Guid cabinetId)

        {
            ShopId = Guid.NewGuid();
            ShopName = shopName;
            CabinetId = cabinetId;
        }

        public Guid ShopId { get; set; }
        public string ShopName { get;  set; }
        public Guid CabinetId { get; set; }
        public List<Drug> Drugs { get;  set; } = new List<Drug>();

        public void AttachCabinet(Cabinet cabinet)
        {
            CabinetId = cabinet.Id;
        }
       
        public void addDrug(Drug drug)
        {
            if(Drugs == null) Drugs = new List<Drug>();
            Drugs.Add(drug);
        }
    }
}