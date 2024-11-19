namespace SmartphoneRentStore.Core.Contracts
{
    using SmartphoneRentStore.Core.Models.Home;
    using SmartphoneRentStore.Core.Models.SmartPhone;

    public interface ISmartphoneService
    {
        Task<IEnumerable<SmartphoneIndexServiceModel>> LastFourSmartphonesAsync();

        Task<IEnumerable<SmartPhoneCategoryServiceModel>> AllCategoriesAsync();

        Task<bool> CategoryExistsAsync(int categoryId);

        Task<int> CreateAsync(SmartPhoneFormModel model, int supplierId);
    }
}
