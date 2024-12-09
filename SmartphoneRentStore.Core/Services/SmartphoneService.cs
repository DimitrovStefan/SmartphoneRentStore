namespace SmartphoneRentStore.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using SmartphoneRentStore.Core.Contracts;
    using SmartphoneRentStore.Core.Enumerations;
    using SmartphoneRentStore.Core.Exeptions;
    using SmartphoneRentStore.Core.Models.Home;
    using SmartphoneRentStore.Core.Models.SmartPhone;
    using SmartphoneRentStore.Infrastructure.Data.Common;
    using SmartphoneRentStore.Infrastructure.Data.Models;
    using static SmartphoneRentStore.Core.Constants.MessageConstants;


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
            var smartphonesToShow = repository.AllReadOnly<SmartPhone>()
                .Where(x => x.IsApproved); // Take all in IQueryable where is approved by admin

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
                                                     .SmartPhonesProjection() // Using IQuerable, Extensions/IQuareableSmartPhoneEx..
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

        public async Task<IEnumerable<SmartPhoneServiceModel>> AllSmartphonesBySupplierIdAsync(int supplierId)
        {
            return await repository.AllReadOnly<SmartPhone>()
                .Where(x => x.IsApproved)
                .Where(x => x.SupplierId == supplierId)
                .SmartPhonesProjection() // again using IQuareable to save memory
                .ToListAsync();
        }

        public async Task<IEnumerable<SmartPhoneServiceModel>> AllSmartphonesByUserIdAsync(string userId)
        {
            return await repository.AllReadOnly<SmartPhone>()
                .Where(x => x.IsApproved)
                .Where(x => x.RenterId == userId)
                .SmartPhonesProjection()
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

        public async Task<bool> ExistsAsync(int id) // check for any match by id
        {
            return await repository.AllReadOnly<SmartPhone>()
                .AnyAsync(x => x.Id == id);
        }

        public async Task<SmartPhoneDetailsServiceModel> SmartphoneDetailsByIdAsync(int id) // Details 
        {
            return await repository.AllReadOnly<SmartPhone>()
                .Where(x => x.Id == id)
                .Where(x => x.IsApproved)
                .Select(x => new SmartPhoneDetailsServiceModel()
                {
                    Id = x.Id,
                    Supplier = new Models.Supplier.SupplierServiceModel()
                    {
                        FullName = $"{x.Supplier.User.FirstName} {x.Supplier.User.LastName}",
                        Email = x.Supplier.User.Email, // from IdentityUser(user) ==> Email?
                        PhoneNumber = x.Supplier.PhoneNumber
                    },
                    Category = x.Category.Name,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    IsRented = x.RenterId != null!,
                    PricePerMonth = x.PricePerMonth,
                    Title = x.Title
                })
                .FirstAsync(); // can return nullable, but every time we will use .ExistsAsync() so it's legit
        }


        public async Task<IEnumerable<SmartphoneIndexServiceModel>> LastFourSmartphonesAsync()
        {
            return await repository
                .AllReadOnly<SmartPhone>()
                .Where(x => x.IsApproved)
                .OrderByDescending(x => x.Id)
                .Take(4)
                .Select(x => new SmartphoneIndexServiceModel()
                {
                    Id = x.Id,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    Title = x.Title
                })
                .ToListAsync();
        }

        public async Task EditAsync(int smartphoneId, SmartPhoneFormModel model)
        {
            var smartphone = await repository.GetByIdAsync<SmartPhone>(smartphoneId);

            if (smartphone != null)
            {
                smartphone.CategoryId = model.CategoryId;
                smartphone.Description = model.Description;
                smartphone.ImageUrl = model.ImageUrl;
                smartphone.PricePerMonth = model.PricePerMonth;
                smartphone.Title = model.Title;

                await repository.SaveChangesAsync();
            }

        }


        public async Task DeleteAsync(int smartphoneId)
        {
            await repository.DeleteAsync<SmartPhone>(smartphoneId);
            await repository.SaveChangesAsync();
        }


        public async Task<bool> HasSupplierWithIdAsync(int smartphoneId, string userId)
        {
            return await repository.AllReadOnly<SmartPhone>()
                .AnyAsync(x => x.Id == smartphoneId && x.Supplier.UserId == userId);
        }

        public async Task<SmartPhoneFormModel?> GetSmartphoneFormModelByIdAsync(int id)
        {
            var smartphone = await repository.AllReadOnly<SmartPhone>()
                .Where(x => x.IsApproved)
                .Where(x => x.Id == id)
                .Select(x => new SmartPhoneFormModel()
                {
                    CategoryId = x.CategoryId,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    PricePerMonth = x.PricePerMonth,
                    Title = x.Title,
                })
                .FirstOrDefaultAsync();

            if (smartphone != null)
            {
                smartphone.Categories = await AllCategoriesAsync();
            }

            return smartphone;
        }

        public async Task<bool> IsRentedAsync(int smartphoneId)
        {
            bool result = false;

            var smartphone = await repository.GetByIdAsync<SmartPhone>(smartphoneId);

            if (smartphone != null)
            {
                result = smartphone.RenterId != null;
            }

            return result;
        }

        public async Task<bool> IsRentedByUserWithIdAsync(int smartphoneId, string userId)
        {
            bool result = false;

            var smartphone = await repository.GetByIdAsync<SmartPhone>(smartphoneId);

            if (smartphone != null)
            {
                result = smartphone.RenterId == userId; // if it is the current user will give me back true;
            }

            return result;
        }

        public async Task RentAsync(int id, string userId)
        {
            var smartphone = await repository.GetByIdAsync<SmartPhone>(id);

            if (smartphone != null)
            {
                smartphone.RenterId = userId;
                await repository.SaveChangesAsync();
            }
        }

        public async Task LeaveAsync(int smartphoneId, string userId)
        {
            var smartphone = await repository.GetByIdAsync<SmartPhone>(smartphoneId);

            if (smartphone != null)
            {
                if (smartphone.RenterId != userId)
                {
                    throw new UnauthorizedActionExeption(NotRenterUserError);
                }

                smartphone.RenterId = null;
                await repository.SaveChangesAsync();
            }
        }

        public async Task ApproveSmartphoneAsync(int smartphoneId)
        {
            var smartphone = await repository.GetByIdAsync<SmartPhone>(smartphoneId);

            if (smartphone != null && smartphone.IsApproved == false)
            {
                smartphone.IsApproved = true;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SmartPhoneServiceModel>> GetUnApprovedAsync()
        {
            return await repository.AllReadOnly<SmartPhone>()
                .Where(x => x.IsApproved == false)
                .Select(x => new SmartPhoneServiceModel()
                { 
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    Id = x.Id,
                    IsRented = false,
                    PricePerMonth = x.PricePerMonth,
                    Title = x.Title
                })
                .ToListAsync();
        }
    }
}
