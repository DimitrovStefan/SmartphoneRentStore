namespace SmartphoneRentStore.Core.Contracts
{
    using SmartphoneRentStore.Core.Models.Statistics;
    using SmartphoneRentStore.Core.Services;


    public interface IStatisticService
    {
        Task<StatisticServiceModel> TotalAsync();


    }
}
