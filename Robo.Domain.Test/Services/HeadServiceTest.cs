using Moq.AutoMock;
using Robo.Domain.Enums;
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

        [Fact]
        public void PutRotation_ShouldSetTheNewRotationAndReturnHead()
        {
            //Arrange
            var head = new Head();
            var rotation = HeadRotation.Minus45;
            var headService = _autoMocker.CreateInstance<HeadService>();

            //Act
            var result = headService.PutRotation(head, rotation);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Head>(result);
            Assert.Equal(rotation, result.HeadRotation);
        }

        [Fact]
        public void PutTilt_ShouldSetTheNewTiltAndReturnHead()
        {
            //Arrange
            var head = new Head();
            var headService = _autoMocker.CreateInstance<HeadService>();

            //Act
            var result = headService.PutTilt(head, Tilt.Down);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Head>(result);
            Assert.Equal(Tilt.Down, result.Tilt);
        }
    }
}