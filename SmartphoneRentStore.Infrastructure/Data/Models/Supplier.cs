namespace SmartphoneRentStore.Infrastructure.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static SmartphoneRentStore.Infrastructure.Constants.DataConstants;

    [Index(nameof(PhoneNumber), IsUnique = true)]
    [Comment("Smartphone supplier")]
    public class Supplier
    {
        [Key]
        [Comment("Supplier identifier")]
        public int Id { get; set; }

        [Required] // ?
        [MaxLength(SupplierPhoneMaxLength)]
        [Comment("Supplier phone number")]
        public required string PhoneNumber { get; set; }

        [Required] // ?
        [MaxLength(SupplierCityMaxLength)]
        [Comment("Supplier based city")]
        public required string City { get; set; }

        [Required] //?
        [Comment("User identifier")]
        public required string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        public virtual ICollection<SmartPhone> SmartPhones { get; set; } = new List<SmartPhone>();
    }
}
