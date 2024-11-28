namespace SmartphoneRentStore.Core.Models.SmartPhone
{
    public class SmartPhoneDetailsViewModel
    {

        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;


        public string ImageUrl { get; set; } = string.Empty;
        
        public decimal PricePerMonth { get; set; }
        
        public string Description { get; set; } = string.Empty;


    }
}
