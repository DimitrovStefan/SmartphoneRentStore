namespace SmartphoneRentStore.Core.Models.SmartPhone
{
    using SmartphoneRentStore.Core.Contracts;
    using System.ComponentModel.DataAnnotations;
    using static SmartphoneRentStore.Core.Constants.MessageConstants;
    using static SmartphoneRentStore.Infrastructure.Constants.DataConstants;


    public class SmartPhoneServiceModel : ISmartphoneModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(SmartphoneTitleMaxLength, MinimumLength = SmartphoneTitleMinLength,
            ErrorMessage = LengthMessage)]
        public required string Title { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(SmartphoneDescriptionMaxLength, MinimumLength = SmartphoneDescriptionMinLength,
            ErrorMessage = LengthMessage)]
        public required string Description { get; set; }


        [Display(Name = "Image URL")]
        public required string ImageUrl { get; set; }


        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal), SmartphonePriceMinLength,
                                SmartphonePriceMaxLength,
                                ConvertValueInInvariantCulture = true,
                                ErrorMessage = LengthMessage)]
        [Display(Name = "Price Per Month")]
        public required decimal PricePerMonth { get; set; }

        [Display(Name = "Is Rented")]
        public required bool IsRented { get; set; }

        public bool IsDeleted { get; set; }

        

    }
}