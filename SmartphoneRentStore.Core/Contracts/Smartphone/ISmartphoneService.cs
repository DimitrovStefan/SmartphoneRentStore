using SmartphoneRentStore.Core.Models.Home;

namespace SmartphoneRentStore.Core.Contracts.Smartphone
{
    public interface ISmartphoneService
    {
        Task<IEnumerable<SmartphoneIndexServiceModel>> LastFourSmartphones();

    }
}
