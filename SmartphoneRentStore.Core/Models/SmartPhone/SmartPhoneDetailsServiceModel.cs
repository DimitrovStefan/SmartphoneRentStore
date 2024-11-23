namespace SmartphoneRentStore.Core.Models.SmartPhone
{
    using SmartphoneRentStore.Core.Models.Supplier;


    public class SmartPhoneDetailsServiceModel : SmartPhoneServiceModel
    {
        public required string Description { get; set; }

        public required string Category { get; set; }

        public required SupplierServiceModel Supplier { get; set; }

    }
}
