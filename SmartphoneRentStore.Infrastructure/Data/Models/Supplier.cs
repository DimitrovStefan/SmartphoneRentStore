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
        public string PhoneNumber { get; set; } = null!;

        [Required] // ?
        [MaxLength(SupplierCityMaxLength)]
        [Comment("Supplier based city")]
        public  string City { get; set; } = null!;

        [Required] //?
        [Comment("User identifier")]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        public virtual ICollection<SmartPhone> SmartPhones { get; set; } = new List<SmartPhone>();
    }
}
