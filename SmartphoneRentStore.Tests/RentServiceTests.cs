using Moq;
using MockQueryable.Moq;
using SmartphoneRentStore.Core.Services;
using SmartphoneRentStore.Infrastructure.Data.Common;
using SmartphoneRentStore.Infrastructure.Data.Models;
using MockQueryable;

namespace SmartphoneRentStore.Tests
{
    [TestFixture]
    public class RentServiceTests
    {
        private Mock<IRepository> mockRepository;
        private RentService rentService;

        [SetUp]
        public void Setup()
        {
            mockRepository = new Mock<IRepository>();
            rentService = new RentService(mockRepository.Object);
        }

        [Test]
        public async Task AllAsyncRentServiceModels()
        {
            // Arrange
            var mockSmartphones = new List<SmartPhone>
            {
                new SmartPhone
                {
                    Description = "DescTest",
                    Supplier = new Supplier
                    {
                        User = new ApplicationUser
                        {
                            Email = "TestEmail@test.bg",
                            FirstName = "FirstNameTest",
                            LastName = "LastNameTest"
                        }
                    },
                    Renter = new ApplicationUser
                    {
                        Email = "EmailRenterTest",
                        FirstName = "FirstNameTest",
                        LastName = "LastNameTest"
                    },
                    RenterId = "1",
                    ImageUrl = "ImageURLTest",
                    Title = "TitleTest",
                    Id = 1
                }
            }.AsQueryable().BuildMock();

            mockRepository
                .Setup(r => r.AllReadOnly<SmartPhone>())
                .Returns(mockSmartphones);

            // Act
            var result = await rentService.AllAsync();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(1));

            var firstItem = result.First();
            Assert.That(firstItem.SupplierEmail, Is.EqualTo("TestEmail@test.bg"));
            Assert.That(firstItem.SupplierFullName, Is.EqualTo("FirstNameTest LastNameTest"));
            Assert.That(firstItem.SmartphoneImageUrl, Is.EqualTo("ImageURLTest"));
            Assert.That(firstItem.SmartphoneTitle, Is.EqualTo("TitleTest"));
            Assert.That(firstItem.RenterEmail, Is.EqualTo("EmailRenterTest"));
            Assert.That(firstItem.RenterFullName, Is.EqualTo("FirstNameTest LastNameTest"));
        }


        
    }
}
