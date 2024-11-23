namespace SmartphoneRentStore.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using SmartphoneRentStore.Core.Contracts;
    using SmartphoneRentStore.Core.Models.SmartPhone;
    using SmartphoneRentStore.Infrastructure.Data.Common;
    using SmartphoneRentStore.Infrastructure.Data.Models;

    public class SupplierService : ISupplierService
    {
        private readonly IRepository repository;

        public SupplierService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task CreateAsync(string userId, string phonenumber, string city)
        {
            await repository.AddAsync(new Supplier()
            {
                UserId = userId,
                PhoneNumber = phonenumber,
                City = city
            });

            await repository.SaveChangesAsync();
        }


        public async Task<bool> ExistsByIdAsync(string userId) // check if any supplier exist by id 
        {
            return await repository.AllReadOnly<Supplier>()
                .AnyAsync(x => x.UserId == userId);
        }

        

        public async Task<int?> GetSupplierIdAsync(string userId) // will give me a id or null if don't find it
        {
            return (await repository.AllReadOnly<Supplier>()
                .FirstOrDefaultAsync(x => x.UserId == userId))?.Id;
        }



        
        public async Task<bool> UserHasRentsAsync(string userId) // check if the user rent some smartphone
        {
            return await repository.AllReadOnly<SmartPhone>()
                .AnyAsync(x => x.RenterId == userId);
        }

        public async Task<bool> UserWithPhoneNumberExistsAsync(string phonenumber) // check if some supplier have the same phonenumber
        {
            return await repository.AllReadOnly<Supplier>()
                .AnyAsync(x => x.PhoneNumber == phonenumber);
        }
    }
}
