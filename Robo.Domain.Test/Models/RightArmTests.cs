using Robo.Domain.Enums;
using Robo.Domain.Models;

namespace Robo.Domain.Test.Models
{
    public class RightArmTests
    {
        [Fact]
        public void RightArm_InitialState_ShouldBeRest()
        {
            //Arrange

            //Act
            var result = new RightArm();

            //Assert
            Assert.Equal(Contracted.Rest, result.Elbow.Contracted);
            Assert.Equal(ArmRotation.Rest, result.Wrist.ArmRotation);
        }

        [Theory]
        [InlineData(ArmRotation.Minus45)]
        [InlineData(ArmRotation.Rest)]
        [InlineData(ArmRotation.Plus45)]
        public void MovementWrist_WithElbowStronglyContracted_ShouldMovementTheWrist(ArmRotation rotation)
        {
            //Arrange
            var rightArm = new RightArm();
            rightArm.Elbow.setContracted(Contracted.StronglyContracted);

            //Act
            rightArm.MovementWrist(rotation);

            //Assert
            Assert.Equal(rotation, rightArm.Wrist.ArmRotation);
        }

        [Theory]
        [InlineData(Contracted.Rest)]
        [InlineData(Contracted.SlightlyContracted)]
        [InlineData(Contracted.Contracted)]
        public void MovementWrist_WithElbowDifferentThanStronglyContracted_ShouldNotMovementTheWrist(Contracted contracted)
        {
            //Arrange
            var rightArm = new RightArm();
            rightArm.Elbow.setContracted(contracted);

            //Act
            //Assert
            var exception = Assert.Throws<Exception>(() => rightArm.MovementWrist(ArmRotation.Plus135));
            Assert.Equal("You can't movement wrist, because the elbow is not strongly contracted", exception.Message);
        }

        [Theory]
        [InlineData(ArmRotation.Plus180)]
        [InlineData(ArmRotation.Plus135)]
        [InlineData(ArmRotation.Plus90)]
        [InlineData(ArmRotation.Minus90)]
        public void MovementWrist_JumpAState_ShouldNotRotationTheWrist(ArmRotation rotation)
        {
            //Arrange
            var rightArm = new RightArm();
            rightArm.Elbow.setContracted(Contracted.StronglyContracted);

            //Act
            //Assert
            var exception = Assert.Throws<Exception>(() => rightArm.MovementWrist(rotation));
            Assert.Equal("You can't rotation the wrist, because it`s jump a state", exception.Message);
        }
    }
}