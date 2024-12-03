using SmartphoneRentStore.Core.Contracts;

namespace SmartphoneRentStore.Core.Models.Home
{
    public class SmartphoneIndexServiceModel : ISmartphoneModel
    {
        public int Id { get; set; }

        public required string Title { get; set; }

        public required string Description { get; set; }

        public required string ImageUrl { get; set; }
    }
}
