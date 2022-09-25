using Robo.Domain.Enums;
using Robo.Domain.Models;

namespace Robo.Domain.Test.Models
{
    public class WristTests
    {
        [Fact]
        public void Wrist_InitialState_ShouldBeRest()
        {
            //Arrange

            //Act
            var result = new Wrist();

            //Assert
            Assert.Equal(ArmRotation.Rest, result.ArmRotation);
        }

        [Theory]
        [InlineData(ArmRotation.Minus45)]
        [InlineData(ArmRotation.Rest)]
        [InlineData(ArmRotation.Plus45)]
        public void MovementWrist_WithElbowStronglyContracted_ShouldMovementTheWrist(ArmRotation rotation)
        {
            //Arrange
            var wrist = new Wrist();

            //Act
            wrist.SetRotation(rotation);

            //Assert
            Assert.Equal(rotation, wrist.ArmRotation);
        }

        [Theory]
        [InlineData(ArmRotation.Plus180)]
        [InlineData(ArmRotation.Plus135)]
        [InlineData(ArmRotation.Plus90)]
        [InlineData(ArmRotation.Minus90)]
        public void SetRotation_JumpAState_ShouldNotRotationTheWrist(ArmRotation rotation)
        {
            //Arrange
            var wrist = new Wrist();

            //Act
            //Assert
            var exception = Assert.Throws<Exception>(() => wrist.SetRotation(rotation));
            Assert.Equal("You can't rotation the wrist, because it`s jump a state", exception.Message);
        }
    }
}