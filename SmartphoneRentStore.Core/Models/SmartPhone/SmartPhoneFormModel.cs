namespace SmartphoneRentStore.Core.Models.SmartPhone
{
    using System.ComponentModel.DataAnnotations;
    using static SmartphoneRentStore.Core.Constants.MessageConstants;
    using static SmartphoneRentStore.Infrastructure.Constants.DataConstants;

    public class SmartPhoneFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(SmartphoneTitleMaxLength, MinimumLength = SmartphoneTitleMinLength,
            ErrorMessage = LengthMessage)]
        public string Title { get; set; } = null!;


        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(SmartphoneDescriptionMaxLength, MinimumLength = SmartphoneDescriptionMinLength,
            ErrorMessage = LengthMessage)]
        public string Description { get; set; } = null!;


        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal), SmartphonePriceMinLength, 
                                SmartphonePriceMaxLength, 
                                ConvertValueInInvariantCulture = true,
                                ErrorMessage = LengthMessage)]
        [Display(Name = "Price Per Month")]
        public decimal PricePerMonth { get; set; }


        [Display(Name = "Category")]
        public int CategoryId { get; set; }


        public IEnumerable<SmartPhoneCategoryServiceModel> Categories { get; set; } =
            new List<SmartPhoneCategoryServiceModel>();


    }
}
