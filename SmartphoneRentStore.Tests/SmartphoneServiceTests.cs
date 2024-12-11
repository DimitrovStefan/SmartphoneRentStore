namespace SmartphoneRentStore.Tests
{
    using Moq;
    using SmartphoneRentStore.Infrastructure.Data.Common;
    using SmartphoneRentStore.Infrastructure.Data.Models;

    [TestFixture]
    public class SmartphoneServiceTests
    {
        [TestFixture]
        public class RepositoryTests
        {
            private Mock<IRepository> mockRepository;

            [SetUp]
            public void Setup()
            {
                mockRepository = new Mock<IRepository>();
            }

            [Test]
            public async Task AddAsync_AddsEntityToRepository()
            {
                // Arrange
                var smartphone = new SmartPhone
                {
                    Title = "Test Smartphone",
                    Description = "Test Description",
                    ImageUrl = "https://example.com/image.jpg",
                    PricePerMonth = 15.00m,
                    CategoryId = 1,
                    SupplierId = 1,
                    IsApproved = true
                };

                mockRepository
                    .Setup(r => r.AddAsync(It.IsAny<SmartPhone>()))
                    .Returns(Task.CompletedTask);

                // Act
                await mockRepository.Object.AddAsync(smartphone);

                // Assert
                mockRepository.Verify(r => r.AddAsync(It.Is<SmartPhone>(s =>
                    s.Title == smartphone.Title &&
                    s.Description == smartphone.Description &&
                    s.ImageUrl == smartphone.ImageUrl &&
                    s.PricePerMonth == smartphone.PricePerMonth &&
                    s.CategoryId == smartphone.CategoryId &&
                    s.SupplierId == smartphone.SupplierId &&
                    s.IsApproved == smartphone.IsApproved
                )), Times.Once);
            }




            [Test]
            public async Task GetByIdAsync_ReturnsEntityById()
            {
                // Arrange
                var smartphoneId = 1;
                var expectedSmartphone = new SmartPhone
                {
                    Id = smartphoneId,
                    Title = "Test Smartphone",
                    Description = "Test Description",
                    ImageUrl = "https://example.com/image.jpg",
                    PricePerMonth = 15.00m,
                    CategoryId = 1,
                    SupplierId = 1,
                    IsApproved = true
                };

                mockRepository
                    .Setup(r => r.GetByIdAsync<SmartPhone>(smartphoneId))
                    .ReturnsAsync(expectedSmartphone);

                // Act
                var result = await mockRepository.Object.GetByIdAsync<SmartPhone>(smartphoneId);

                // Assert
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Id, Is.EqualTo(smartphoneId));
                Assert.That(result.Title, Is.EqualTo(expectedSmartphone.Title));
                Assert.That(result.Description, Is.EqualTo(expectedSmartphone.Description));
                Assert.That(result.ImageUrl, Is.EqualTo(expectedSmartphone.ImageUrl));
                Assert.That(result.PricePerMonth, Is.EqualTo(expectedSmartphone.PricePerMonth));
                Assert.That(result.CategoryId, Is.EqualTo(expectedSmartphone.CategoryId));
                Assert.That(result.SupplierId, Is.EqualTo(expectedSmartphone.SupplierId));
                Assert.That(result.IsApproved, Is.True);

                 mockRepository.Verify(r => r.GetByIdAsync<SmartPhone>(smartphoneId), Times.Once);
            }
        }
    }

}
