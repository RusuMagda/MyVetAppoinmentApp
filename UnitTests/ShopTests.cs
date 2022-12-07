

using MyVetAppoinment.Domain.Entities;

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
            Shop shop = new Shop("MyShop");

            Assert.NotNull(shop);

            Cabinet cabinet = new Cabinet("ProVet", "Strada Smardan 84");
            shop.AttachCabinet(cabinet);

            shop.CabinetId.Equals(cabinet.Id);
        }

        [Fact]
        public void WhenAddDrug() 
        {
            Shop shop = new Shop("MyShop");

            Assert.NotNull(shop);

            Drug drug = new Drug("NeuroVet", "este indicat pentru tratamentul adjuvant al neuropatiilor", 50, 169, "comprimate", 60, "comprimate");
            Assert.NotNull(drug);

            shop.addDrug(drug);
            shop.Drugs.Count.Equals(1);
            shop.Drugs[0].Equals(drug);
        }
    }
}
