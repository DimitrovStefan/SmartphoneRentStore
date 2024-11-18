using SmartphoneRentStore.Core.Models.Home;

namespace SmartphoneRentStore.Core.Contracts
{
    public interface ISmartphoneService
    {
        Task<IEnumerable<SmartphoneIndexServiceModel>> LastFourSmartphonesAsync();

    }
}
