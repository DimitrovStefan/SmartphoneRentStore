namespace SmartphoneRentStore.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using SmartphoneRentStore.Core.Contracts;
    using SmartphoneRentStore.Core.Models.Admin;
    using SmartphoneRentStore.Infrastructure.Data.Common;
    using SmartphoneRentStore.Infrastructure.Data.Models;



    public class RentService : IRentService
    {
        private readonly IRepository repository;

        public RentService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<RentServiceModel>> AllAsync()
        {
            return await repository.AllReadOnly<SmartPhone>()
                .Where(x => x.RenterId != null)
                .Include(x => x.Supplier)
                .Include(x => x.Renter)
                .Select(x => new RentServiceModel()
                {
                    SupplierEmail = x.Supplier.User.Email,
                    SupplierFullName = $"{x.Supplier.User.FirstName} {x.Supplier.User.LastName}",
                    SmartphoneImageUrl = x.ImageUrl,
                    SmartphoneTitle = x.Title,
                    RenterEmail = x.Renter != null ? x.Renter.Email : string.Empty,
                    RenterFullName = x.Renter != null ? $"{x.Renter.FirstName} {x.Renter.LastName}" : string.Empty

                })
                .ToListAsync();
                
        }
    }
}
