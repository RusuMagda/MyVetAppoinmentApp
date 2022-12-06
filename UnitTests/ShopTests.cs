

using MyVetAppoinment.Domain.Entities;

namespace UnitTests
{
    public class ShopTests
    {
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
