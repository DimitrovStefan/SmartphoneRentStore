namespace SmartphoneRentStore.Core.Models.Supplier
{
    using System.ComponentModel.DataAnnotations;
    using static SmartphoneRentStore.Core.Constants.MessageConstants;
    using static SmartphoneRentStore.Infrastructure.Constants.DataConstants;

    public class BecomeSupplierFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(SupplierPhoneMaxLength,
            MinimumLength = SupplierPhoneMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; } = null!;
        

        
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(SupplierCityMaxLength, 
            MinimumLength = SupplierCityMinLength,
            ErrorMessage = LengthMessage)]
        public string City { get; set; } = null!;
    }
}
