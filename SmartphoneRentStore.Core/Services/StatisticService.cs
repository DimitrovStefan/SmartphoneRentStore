namespace SmartphoneRentStore.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using SmartphoneRentStore.Core.Contracts;
    using SmartphoneRentStore.Core.Models.Statistics;
    using SmartphoneRentStore.Infrastructure.Data.Common;
    using SmartphoneRentStore.Infrastructure.Data.Models;
    using System.Threading.Tasks;

    public class StatisticService : IStatisticService
    {
        private readonly IRepository repository;

        public StatisticService(IRepository _repository) // injection
        {
                repository = _repository;
        }

        public async Task<StatisticServiceModel> TotalAsync()
        {
            int totalSmartphones = await repository.AllReadOnly<SmartPhone>()
                .CountAsync();

            int totalRents = await repository.AllReadOnly<SmartPhone>()
                .Where(x => x.RenterId != null)
                .CountAsync();

            return new StatisticServiceModel()
            { 
                TotalSmartphones = totalSmartphones,
                TotalRents = totalRents
            };
        }
    }
}
