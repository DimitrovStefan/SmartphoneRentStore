namespace SmartphoneRentStore.Core.Services.Smartphone
{
    using Microsoft.EntityFrameworkCore;
    using SmartphoneRentStore.Core.Contracts.Smartphone;
    using SmartphoneRentStore.Core.Models.Home;
    using SmartphoneRentStore.Infrastructure.Data.Common;

    public class SmartphoneService : ISmartphoneService
    {
        private readonly IRepository repository;

        public SmartphoneService(IRepository _repository) // repository injection
        {
            repository = _repository;
        }


        public async Task<IEnumerable<SmartphoneIndexServiceModel>> LastFourSmartphones()
        {
            return await repository
                .AllReadOnly<Infrastructure.Data.Models.SmartPhone>()
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
