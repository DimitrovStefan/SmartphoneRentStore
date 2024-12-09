using SmartphoneRentStore.Core.Models.Admin.User;

namespace SmartphoneRentStore.Core.Contracts
{
    public interface IUserService
    {
        Task<string> UserFullNameAsync(string userId);

        Task<IEnumerable<UserServiceModel>> AllAsync();

    }
}
