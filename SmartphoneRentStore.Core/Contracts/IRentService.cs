
namespace SmartphoneRentStore.Core.Contracts
{
    using SmartphoneRentStore.Core.Models.Admin;


    public interface IRentService
    {
        Task<IEnumerable<RentServiceModel>> AllAsync();
    }
}
