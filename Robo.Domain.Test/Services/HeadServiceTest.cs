using Moq.AutoMock;
using Robo.Domain.Models;
using Robo.Domain.Services;

namespace Robo.Domain.Test.Services
{
    public class HeadServiceTest
    {
        private readonly AutoMocker _autoMocker;

        public HeadServiceTest()
        {
            _autoMocker = new AutoMocker();
        }

        [Fact]
        public void CreateHead_ShouldCreateAndReturnHead()
        {
            //Arrange
            var headService = _autoMocker.CreateInstance<HeadService>();

            //Act
            var result = headService.CreateHead();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Head>(result);
        }
    }
}