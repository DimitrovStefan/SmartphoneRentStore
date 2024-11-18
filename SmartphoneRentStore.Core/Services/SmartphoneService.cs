namespace SmartphoneRentStore.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using SmartphoneRentStore.Core.Contracts;
    using SmartphoneRentStore.Core.Models.Home;
    using SmartphoneRentStore.Infrastructure.Data.Common;
    using SmartphoneRentStore.Infrastructure.Data.Models;

    public class SmartphoneService : ISmartphoneService
    {
        private readonly IRepository repository;

        public SmartphoneService(IRepository _repository) // repository injection
        {
            repository = _repository;
        }


        public async Task<IEnumerable<SmartphoneIndexServiceModel>> LastFourSmartphonesAsync()
        {
            return await repository
                .AllReadOnly<SmartPhone>()
                .OrderByDescending(x => x.Id)
                .Take(4)
                .Select(x => new SmartphoneIndexServiceModel()
                {
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                    Title = x.Title
                })
                .ToListAsync();
        }
    }
}
