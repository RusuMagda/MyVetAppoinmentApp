

using MyVetAppoinment.Domain.Entities;

namespace UnitTests
{
    public class ShopTests
    {
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

            Drug drug = new Drug("NeuroVet", "este indicat pentru tratamentul adjuvant al neuropatiilor", 50, 169, "comprimate", 60, "comprimate");
            Assert.NotNull(drug);

            shop.addDrug(drug);
            shop.Drugs.Count.Equals(1);
            shop.Drugs[0].Equals(drug);
        }
    }
}
