

using MyVetAppointment.Domain.Entities;

namespace UnitTests
{
    public class ShopTests
    {
        [Fact]
        public void WhenCreateShopWithId()
        {
            var shopId = new Guid("9074d219-a6a1-43c0-808d-c717e0c95c49");
            var cabinetId = new Guid("04990752-4d6b-4fc3-9230-cef255b6219a");
            var name = "MyShop";
            var result = new Shop(shopId, name, cabinetId);

            Assert.NotNull(result);
            result.ShopId.Equals(new Guid("9074d219-a6a1-43c0-808d-c717e0c95c49"));
            result.CabinetId.Equals(new Guid("04990752-4d6b-4fc3-9230-cef255b6219a"));
            result.ShopName.Equals("MyShop");
        }
        [Fact]
        public void WhenAttachCabinet()
        {
            Shop shop = new Shop("MyShop", new Guid("d42fbb91-0ebe-43ea-b91c-b9b026430f09"));

            Assert.NotNull(shop);

            Cabinet cabinet = new Cabinet("ProVet", "Strada Smardan 84");
            shop.AttachCabinet(cabinet);

            shop.CabinetId.Equals(cabinet.Id);
        }

        [Fact]
        public void WhenAddDrug() 
        {
            Shop shop = new Shop("MyShop", new Guid("d42fbb91-0ebe-43ea-b91c-b9b026430f09"));

            Assert.NotNull(shop);

            Drug drug = new Drug(new Guid("d42fbb91-0ebe-43ea-b91c-b9b026430f09"), "NeuroVet", "este indicat pentru tratamentul adjuvant al neuropatiilor", 50, 169, "comprimate", 60, "comprimate");
            Assert.NotNull(drug);

            shop.addDrug(drug);
            shop.Drugs.Count.Equals(1);
            shop.Drugs[0].Equals(drug);
        }
    }
}
