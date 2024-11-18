namespace SmartphoneRentStore.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using SmartphoneRentStore.Core.Contracts;
    using SmartphoneRentStore.Infrastructure.Data.Common;
    using SmartphoneRentStore.Infrastructure.Data.Models;

    public class SupplierService : ISupplierService
    {
        private readonly IRepository repository;

        public SupplierService(IRepository _repository)
        {
            repository = _repository;
        }

        public Task<bool> CreateAsync(string userId, string phonenumber)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsById(string userId) // check if any supplier exist by id 
        {
            return await repository.AllReadOnly<Supplier>()
                .AnyAsync(x => x.UserId == userId);
        }

        public Task<bool> ExistsByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserHasRentsAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserWithPhoneNumberExistsAsync(string phonenumber)
        {
            throw new NotImplementedException();
        }
    }
}
