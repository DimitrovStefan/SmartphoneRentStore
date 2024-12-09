using Microsoft.EntityFrameworkCore;
using SmartphoneRentStore.Core.Contracts;
using SmartphoneRentStore.Core.Models.Admin.User;
using SmartphoneRentStore.Infrastructure.Data.Common;
using SmartphoneRentStore.Infrastructure.Data.Models;

namespace SmartphoneRentStore.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repository;

        public UserService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<UserServiceModel>> AllAsync()
        {
            return await repository.AllReadOnly<ApplicationUser>()
                .Include(x => x.Supplier)
                .Select(x => new UserServiceModel()
                {
                    Email = x.Email,
                    FullName = $"{x.FirstName} {x.LastName}",
                    PhoneNumber = x.Supplier != null ? x.Supplier.PhoneNumber : null,
                    IsSupplier = x.Supplier != null,
                })
                .ToListAsync();
            
        }

        public async Task<string> UserFullNameAsync(string userId)
        {
            string result = string.Empty;
            var user = await repository.GetByIdAsync<ApplicationUser>(userId);

            if (user == null)
            {
                result = $"{user.FirstName} {user.LastName}";
            }

            return result;
        }
    }
}
