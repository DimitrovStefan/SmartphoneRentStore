namespace SmartphoneRentStore.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using SmartphoneRentStore.Core.Contracts;
    using SmartphoneRentStore.Core.Enumerations;
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

        public async Task<SmartPhoneQueryServiceModel> AllAsync(string? category = null, 
                                                                string? searchTern = null, 
                                                                SmartPhoneSorting sorting = SmartPhoneSorting.Newest, 
                                                                int currentPage = 1, 
                                                                int SmartPhonesPerPage = 1)
        {
            var smartphonesToShow = repository.AllReadOnly<SmartPhone>(); // Take all in IQueryable

            if (category != null) // filter by category
            {
                smartphonesToShow = smartphonesToShow.Where(x => x.Category.Name == category);
            }

            if (searchTern != null) // filter by search item
            {
                string regularSearchTern = searchTern.ToLower(); // Make it regular by .ToLower to make success sorting

                smartphonesToShow = smartphonesToShow.Where(x => x.Title.ToLower().Contains(regularSearchTern) ||
                                                                 x.Description.ToLower().Contains(regularSearchTern) ||
                                                                 x.ImageUrl.ToLower().Contains(regularSearchTern));
            }

            smartphonesToShow = sorting switch // (switch expression) sorting
            { 
                SmartPhoneSorting.Price => smartphonesToShow.OrderBy(x => x.PricePerMonth),
                SmartPhoneSorting.NotRentedFirst => smartphonesToShow
                                                    .OrderBy(y => y.RenterId != null) // first order by rented
                                                    .ThenByDescending(y => y.Id), // second order descending by newest
                _ => smartphonesToShow.OrderByDescending(y => y.Id) // default sorting by newest
            };

            var smartphones = await smartphonesToShow.Skip((currentPage - 1) * SmartPhonesPerPage) 
                                                     .Take(SmartPhonesPerPage)
                                                     .Select(x => new SmartPhoneServiceModel()
                                                     { 
                                                         Id = x.Id,
                                                         Title = x.Title,
                                                         Description = x.Description,
                                                         ImageUrl = x.ImageUrl,
                                                         PricePerMonth = x.PricePerMonth,
                                                         IsRented = x.RenterId != null // only if is not null 
                                                     })
                                                     .ToListAsync();
            
            

            int totalSmartphone = await smartphonesToShow.CountAsync();

            return new SmartPhoneQueryServiceModel()
            {
                SmartPhones = smartphones,
                TotalSmartPhoneCount = totalSmartphone
            };

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

        public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
        {
            return await repository.AllReadOnly<Category>()
                .Select(x => x.Name)
                .Distinct()
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
