namespace SmartphoneRentStore.Core.Models.SmartPhone
{
    public class SmartPhoneQueryServiceModel
    {
        public int TotalSmartPhoneCount { get; set; }

        public IEnumerable<SmartPhoneServiceModel> SmartPhones { get; set; } = new List<SmartPhoneServiceModel>();

    }
}
