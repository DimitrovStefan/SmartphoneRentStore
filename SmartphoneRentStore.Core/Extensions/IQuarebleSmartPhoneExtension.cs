using SmartphoneRentStore.Core.Models.SmartPhone;
using SmartphoneRentStore.Infrastructure.Data.Models;

namespace System.Linq
{
    public static class IQuarebleSmartPhoneExtension
    {
        public static IQueryable<SmartPhoneServiceModel> SmartPhonesProjection(this IQueryable<SmartPhone> smartPhones)
        {
            return smartPhones.Select(x => new SmartPhoneServiceModel()
            {
                Id = x.Id,
                PricePerMonth = x.PricePerMonth,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                IsRented = x.RenterId != null,
                Title = x.Title
            });
        }

    }
}
