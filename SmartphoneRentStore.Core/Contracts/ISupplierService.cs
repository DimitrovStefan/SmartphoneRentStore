namespace SmartphoneRentStore.Core.Contracts
{
    public interface ISupplierService
    {
        Task<bool> ExistsByIdAsync(string userId);

        Task<bool> UserWithPhoneNumberExistsAsync(string phonenumber);

        Task<bool> UserHasRentsAsync(string userId);

        Task<bool> CreateAsync(string userId, string phonenumber);
    }
}
