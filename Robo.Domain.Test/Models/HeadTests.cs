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
            Assert.Equal(HeadRotation.Rest, result.HeadRotation);
        }

        [Theory]
        [InlineData(Slope.Up, HeadRotation.Minus45)]
        [InlineData(Slope.Rest, HeadRotation.Plus45)]
        [InlineData(Slope.Rest, HeadRotation.Rest)]
        public void RotationHead_WithSlopeDifferentThanDown_ShouldRotationTheHead(Slope slope, HeadRotation headRotation)
        {
            //Arrange
            var head = new Head();
            head.SetSlope(slope);

            //Act
            head.SetRotation(headRotation);

            //Assert
            Assert.Equal(headRotation, head.HeadRotation);
        }

        [Fact]
        public void RotationHead_WithSlopeLikeDown_ShouldNotRotationTheHead()
        {
            //Arrange
            var head = new Head();
            head.SetSlope(Slope.Down);

            //Act
            //Assert
            var exception = Assert.Throws<Exception>(() => head.SetRotation(HeadRotation.Minus45));
            Assert.Equal("You can't rotation the head, because the head's slope is Down", exception.Message);
        }

        [Theory]
        [InlineData(HeadRotation.Plus90)]
        [InlineData(HeadRotation.Minus90)]
        public void RotationHead_JumpAState_ShouldNotRotationTheHead(HeadRotation rotation)
        {
            //Arrange
            var head = new Head();

            //Act
            //Assert
            var exception = Assert.Throws<Exception>(() => head.SetRotation(rotation));
            Assert.Equal("You can't rotation the head, because it`s jump a state", exception.Message);
        }
    }
}