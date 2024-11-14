namespace SmartphoneRentStore.Infrastructure.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using static SmartphoneRentStore.Infrastructure.Constants.DataConstants;


    [Comment("Smartphone category")]
    public class Category
    {
        [Key]
        [Comment("Category identifier")]
        public int Id { get; set; }

        [Required] // ??
        [MaxLength(NameLength)]
        [Comment("Category name")]
        public required string Name { get; set; }

        [Comment("Navigation propery")]
        public virtual ICollection<SmartPhone> SmartPhones { get; set; } = new List<SmartPhone>();
    }
}
