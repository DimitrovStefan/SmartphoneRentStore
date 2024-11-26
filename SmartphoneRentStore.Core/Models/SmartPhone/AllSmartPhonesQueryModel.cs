using SmartphoneRentStore.Core.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace SmartphoneRentStore.Core.Models.SmartPhone
{
    public class AllSmartPhonesQueryModel
    {
        public int SmartphonesPerPage = 3;

        public required string Category { get; set; }

        [Display(Name = "Search by text")]
        public required string SearchTerm { get; set; }

        public SmartPhoneSorting Sorting{ get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalSmartphoneCount { get; set; }

        public bool isDeleted { get; set; }

        public required virtual IEnumerable<string> Categories { get; set; }

        public required virtual IEnumerable<SmartPhoneServiceModel> SmartPhones { get; set; } = new List<SmartPhoneServiceModel>();
    }
}
