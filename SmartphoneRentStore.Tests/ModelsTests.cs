namespace SmartphoneRentStore.Tests
{
    using SmartphoneRentStore.Infrastructure.Data.Models;


    public class Tests
    {
        Supplier supplier = new Supplier()
        {
            Id = 1,
            City = "Burgas",
            PhoneNumber = "0896969696",
            SmartPhones = new List<SmartPhone>()
        };

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SupplierTest()
        {
            Assert.That(supplier.Id, Is.EqualTo(1));
            Assert.That(supplier.City, Is.EqualTo("Burgas"));
            Assert.That(supplier.SmartPhones, Is.EqualTo(new List<SmartPhone>()));
            Assert.That(supplier.PhoneNumber, Is.EqualTo("0896969696"));
        }

        [Test]
        public void SmartPhoneTest()
        {
            var smartphone = new SmartPhone()
            {
                Id = 1,
                CategoryId = 1,
                Description = "TestDescription",
                Title = "TestTitle",
                ImageUrl = "TestURL",
                PricePerMonth = 10.00M,
                IsApproved = true,
                RenterId = null,
                Supplier = supplier
            };

            Assert.That(smartphone.Id, Is.EqualTo(1));
            Assert.That(smartphone.Description, Is.EqualTo("TestDescription"));
            Assert.That(smartphone.Title, Is.EqualTo("TestTitle"));
            Assert.That(smartphone.ImageUrl, Is.EqualTo("TestURL"));
            Assert.That(smartphone.PricePerMonth, Is.EqualTo(10.00M));
            Assert.That(smartphone.IsApproved, Is.EqualTo(true));
            Assert.That(smartphone.RenterId, Is.EqualTo(null));
            Assert.That(smartphone.Supplier, Is.EqualTo(supplier));
            Assert.That(smartphone.CategoryId, Is.EqualTo(1));
        }


       

    }
}