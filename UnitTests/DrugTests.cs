

using MyVetAppointment.Domain.Entities;

namespace UnitTests
{
    public class DrugTests
    {
        [Fact]
        public void WhenInitializeDrugWithId()
        {
            var Id = new Guid("39191ef4-fd54-4fb1-a428-8615d466fefd");
            var name = "Corpet";
            var description = "Supliment nutritional";
            var stock = 50;
            var price = 199;
            var saleForm = "pastile";
            var quantity = 90;
            var quantityMeasure = "pastile";

            Drug drug = new Drug(Id, name, description, stock, price, saleForm, quantity, quantityMeasure);

            Assert.NotNull(drug);
            drug.Id.Equals(new Guid("39191ef4-fd54-4fb1-a428-8615d466fefd"));
            drug.DrugName.Equals("Corpet");
            drug.DrugDescription.Equals("Supliment nutritional");
            drug.Stock.Equals(50);
            drug.Price.Equals(199);
            drug.SaleForm.Equals("pastile");
            drug.Quantity.Equals(90);
            drug.QuantityMeasure.Equals("pastile");
        }
    }
}
