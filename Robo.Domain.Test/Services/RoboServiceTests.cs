using Moq.AutoMock;
using Robo.Domain.Models;
using Robo.Domain.Services;

namespace Robo.Domain.Test.Services
{
    public class RoboServiceTests
    {
        private readonly AutoMocker _autoMocker;

        public RoboServiceTests()
        {
            _autoMocker = new AutoMocker();
        }

        [Fact]
        public void CreateRobo_ShouldCreateAndReturnRobo()
        {
            //Arrange
            var roboService = _autoMocker.CreateInstance<RoboService>();

            //Act
            var result = roboService.CreateRobo();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<RoboUnit>(result);
        }
    }
}