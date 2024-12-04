namespace SmartphoneRentStore.Core.Models.Supplier
{
    using System.ComponentModel.DataAnnotations;


    public class SupplierServiceModel
    {
        [Display(Name = "Full Name")]
        public required string FullName { get; set; }


        [Display(Name = "Phone number")]
        public required string PhoneNumber { get; set; }

        public required string Email { get; set; }

    }
}
