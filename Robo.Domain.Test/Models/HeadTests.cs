using Robo.Domain.Enums;
using Robo.Domain.Models;

namespace Robo.Domain.Test.Models
{
    public class HeadTests
    {
        [Fact]
        public void Head_InitialState_ShouldBeRest()
        {
            //Arrange

            //Act
            var result = new Head();

            //Assert
            Assert.Equal(Slope.Rest, result.Slope);
            Assert.Equal(Rotation.Rest, result.Rotation);
        }

        [Theory]
        [InlineData(Slope.Up)]
        [InlineData(Slope.Rest)]
        public void RotationHead_WithSlopeDifferentThanDown_ShouldRotationTheHead(Slope slope)
        {
            //Arrange
            var head = new Head();
            var rotation = Rotation.Plus45;
            head.SetSlope(slope);

            //Act
            head.SetRotation(rotation);

            //Assert
            Assert.Equal(rotation, head.Rotation);
        }

        [Fact]
        public void RotationHead_WithSlopeLikeDown_ShouldNotRotationTheHead()
        {
            //Arrange
            var head = new Head();
            head.SetSlope(Slope.Down);

            //Act
            //Assert
            var exception = Assert.Throws<Exception>(() => head.SetRotation(Rotation.Minus45));
            Assert.Equal("You can't rotation the head, because the head's slope is Down", exception.Message);
        }
    }
}