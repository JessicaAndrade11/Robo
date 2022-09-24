using Robo.Domain.Enums;
using Robo.Domain.Models;

namespace Robo.Domain.Test
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
            head.SetSlope(slope);

            //Act
            head.SetRotation(Rotation.Minus45);

            //Assert
            Assert.Equal(Rotation.Minus45, head.Rotation);
        }

        [Fact]
        public void RotationHead_WithSlopeLikeDown_ShouldNotRotationTheHead()
        {
            //Arrange
            var head = new Head();
            head.SetSlope(Slope.Down);

            //Act
            head.SetRotation(Rotation.Minus45);

            //Assert
            Assert.Equal(Rotation.Rest, head.Rotation);
        }
    }
}