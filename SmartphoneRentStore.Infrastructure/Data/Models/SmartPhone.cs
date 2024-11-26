namespace SmartphoneRentStore.Infrastructure.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static SmartphoneRentStore.Infrastructure.Constants.DataConstants;


    [Comment("Smartphone to rent")]
    public class SmartPhone
    {
        [Key]
        [Comment("Smartphone identifier")]
        public int Id { get; set; }

        [Required] // ?
        [MaxLength(SmartphoneTitleMaxLength)]
        [Comment("Smartphone title")]
        public required string Title { get; set; }


        [Required] // ?
        [MaxLength(SmartphoneDescriptionMaxLength)]
        [Comment("Smartphone description")]
        public required string Description { get; set; }

        [Required] // ?
        [Comment("Smartphone image url")]
        public required string ImageUrl { get; set; }

        [Required]
        [Comment("Monthfly price")]
        [Column(TypeName = "decimal(18,2)")]
        //[Range(typeof(decimal), SmartphonePriceMinLength, SmartphonePriceMaxLength, ConvertValueInInvariantCulture = true)]
        public decimal PricePerMonth { get; set; }

        [Required]
        [Comment("Category identifier")]
        public int CategoryId { get; set; }


        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;


        [Required]
        [Comment("Supplier identifier")]
        public int SupplierId { get; set; }

        
        [ForeignKey(nameof(SupplierId))]
        public  Supplier Supplier { get; set; } = null!;

        [Comment("User id of the renterer")]
        public string? RenterId { get; set; }

       [Required]
        [Comment("Used for delete")]
        public bool isDeleted { get; set; }
       
    }
}
