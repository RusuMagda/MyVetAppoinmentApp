namespace MyVetAppoinment.Domain.Entities
{
    public class Shop
    {
        public Shop(string shopName)
        {
            ShopId = Guid.NewGuid();
            ShopName = shopName;
        }

        public Guid ShopId { get;  set; }
        public string ShopName { get;  set; }  
        public Guid CabinetId { get;  set; }
        public List<Drug> Drugs { get;  set; }

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