namespace SmartphoneRentStore.Core.Models.Admin
{
    using SmartphoneRentStore.Core.Models.SmartPhone;


    public class MySmartphonesViewModel
    {
        public IEnumerable<SmartPhoneServiceModel> AddedSmartphones { get; set; }= new List<SmartPhoneServiceModel>();

        public IEnumerable<SmartPhoneServiceModel> RentedSmartphones { get; set; } = new List<SmartPhoneServiceModel>();



    }
}
