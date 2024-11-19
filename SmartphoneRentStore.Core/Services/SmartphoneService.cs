namespace SmartphoneRentStore.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using SmartphoneRentStore.Core.Contracts;
    using SmartphoneRentStore.Core.Models.Home;
    using SmartphoneRentStore.Core.Models.SmartPhone;
    using SmartphoneRentStore.Infrastructure.Data.Common;
    using SmartphoneRentStore.Infrastructure.Data.Models;

    public class SmartphoneService : ISmartphoneService
    {
        private readonly IRepository repository;

        public SmartphoneService(IRepository _repository) // repository injection
        {
            repository = _repository;
        }

        public async Task<IEnumerable<SmartPhoneCategoryServiceModel>> AllCategoriesAsync()
        {
            return await repository.AllReadOnly<Category>()
                .Select(c => new SmartPhoneCategoryServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<bool> CategoryExistsAsync(int categoryId)
        {
            return await repository.AllReadOnly<Category>()
                .AnyAsync(c => c.Id == categoryId);
        }


        public async Task<int> CreateAsync(SmartPhoneFormModel model, int supplierId)
        {
            SmartPhone smartPhone = new SmartPhone()
            { 
                Description = model.Description,
                SupplierId = supplierId,
                CategoryId = model.CategoryId,
                ImageUrl = model.ImageUrl,
                PricePerMonth = model.PricePerMonth,
                Title = model.Title
            };

            await repository.AddAsync(smartPhone);
            await repository.SaveChangesAsync();

            return smartPhone.Id;
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
