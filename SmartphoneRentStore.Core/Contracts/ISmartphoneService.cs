namespace SmartphoneRentStore.Core.Contracts
{
    using SmartphoneRentStore.Core.Enumerations;
    using SmartphoneRentStore.Core.Models.Home;
    using SmartphoneRentStore.Core.Models.SmartPhone;

    public interface ISmartphoneService
    {
        Task<IEnumerable<SmartphoneIndexServiceModel>> LastFourSmartphonesAsync();

        Task<IEnumerable<SmartPhoneCategoryServiceModel>> AllCategoriesAsync();

        Task<bool> CategoryExistsAsync(int categoryId);

        Task<int> CreateAsync(SmartPhoneFormModel model, int supplierId);

        Task<SmartPhoneQueryServiceModel> AllAsync(string? category = null,
                                              string? searchTern = null,
                                              SmartPhoneSorting sorting = SmartPhoneSorting.Newest,
                                              int currentPage = 1,
                                              int SmartPhonesPerPage = 1);

        Task<IEnumerable<string>> AllCategoriesNamesAsync();

        Task<IEnumerable<SmartPhoneServiceModel>> AllSmartphonesBySupplierIdAsync(int supplierId);

        Task<IEnumerable<SmartPhoneServiceModel>> AllSmartphonesByUserIdAsync(string userId);

        Task<bool> ExistsAsync(int id);

        Task<SmartPhoneDetailsServiceModel> SmartphoneDetailsByIdAsync(int id);

        Task EditAsync(int smartphoneId, SmartPhoneFormModel model);

        Task DeleteAsync(int smartphoneId);

        Task<bool> HasSupplierWithIdAsync(int smartphoneId, string userId); // check if we have the same Supplier

        Task<SmartPhoneFormModel?> GetSmartphoneFormModelByIdAsync(int id);

        Task<bool> IsRentedAsync(int smartphoneId);

        Task<bool> IsRentedByUserWithIdAsync(int smartphoneId, string userId);

        Task RentAsync(int id, string userId);
        
        Task LeaveAsync(int smartphoneId, string userId);

    }
}
