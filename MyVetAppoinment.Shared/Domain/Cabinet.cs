﻿namespace MyVetAppoinment.Shared.Domain
{
    public class Cabinet
    {


        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get;  set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;

    }
}
