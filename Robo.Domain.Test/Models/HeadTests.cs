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
            Assert.Equal(Tilt.Rest, result.Tilt);
            Assert.Equal(HeadRotation.Rest, result.HeadRotation);
        }

        [Theory]
        [InlineData(Tilt.Up, HeadRotation.Minus45)]
        [InlineData(Tilt.Rest, HeadRotation.Plus45)]
        [InlineData(Tilt.Rest, HeadRotation.Rest)]
        public void RotationHead_WithTiltDifferentThanDown_ShouldRotationTheHead(Tilt tilt, HeadRotation headRotation)
        {
            //Arrange
            var head = new Head();
            head.SetTilt(tilt);

            //Act
            head.SetRotation(headRotation);

            //Assert
            Assert.Equal(headRotation, head.HeadRotation);
        }

        [Fact]
        public void RotationHead_WithTiltLikeDown_ShouldNotRotationTheHead()
        {
            //Arrange
            var head = new Head();
            head.SetTilt(Tilt.Down);

            //Act
            //Assert
            var exception = Assert.Throws<Exception>(() => head.SetRotation(HeadRotation.Minus45));
            Assert.Equal("You can't rotation the head, because the head's tilt is Down", exception.Message);
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

        [Theory]
        [InlineData(Tilt.Up)]
        [InlineData(Tilt.Rest)]
        [InlineData(Tilt.Down)]
        public void TiltHead_ShouldTiltTheHead(Tilt tilt)
        {
            //Arrange
            var head = new Head();

            //Act
            head.SetTilt(tilt);

            //Assert
            Assert.Equal(tilt, head.Tilt);
        }

        [Theory]
        [InlineData(Tilt.Down, Tilt.Up)]
        [InlineData(Tilt.Up, Tilt.Down)]
        public void TiltHead_JumpAState_ShouldNotTiltTheHead(Tilt currentTilt, Tilt nextTilt)
        {
            //Arrange
            var head = new Head();
            head.SetTilt(currentTilt);

            //Act
            //Assert
            var exception = Assert.Throws<Exception>(() => head.SetTilt(nextTilt));
            Assert.Equal("You can't tilt the head, because it`s jump a state", exception.Message);
        }
    }
}