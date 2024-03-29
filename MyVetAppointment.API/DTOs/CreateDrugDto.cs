﻿namespace MyVetAppointment.API.DTOs
{
    public class CreateDrugDto
    {
        public string DrugName { get; set; } = string.Empty;
        public string DrugDescription { get; set; } = string.Empty;
        public int Stock { get; set; } = default(int);
        public int Price { get; set; } = default(int);
        public string SaleForm { get; set; } = string.Empty;
        public int Quantity { get; set; } = default(int);
        public string QuantityMeasure { get; set; } = string.Empty;
        public Guid ShopId { get; set; }
    }
}
