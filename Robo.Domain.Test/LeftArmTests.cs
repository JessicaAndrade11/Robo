using Robo.Domain.Enums;
using Robo.Domain.Models;

namespace Robo.Domain.Test
{
    public class LeftArmTests
    {
        [Fact]
        public void leftArm_InitialState_ShouldBeRest()
        {
            //Arrange

            //Act
            var result = new LeftArm();

            //Assert
            Assert.Equal(Contracted.Rest, result.Elbow.Contracted);
            Assert.Equal(Rotation.Rest, result.Wrist.Rotation);
        }

        [Theory]
        [InlineData(Rotation.Minus90)]
        [InlineData(Rotation.Minus45)]
        [InlineData(Rotation.Rest)]
        [InlineData(Rotation.Plus45)]
        [InlineData(Rotation.Plus90)]
        [InlineData(Rotation.Plus135)]
        [InlineData(Rotation.Plus180)]
        public void MovementWrist_WithElbowStronglyContracted_ShouldMovementTheWrist(Rotation rotation)
        {
            //Arrange
            var leftArm = new LeftArm();
            leftArm.Elbow.setContracted(Contracted.StronglyContracted);

            //Act
            leftArm.MovementWrist(rotation);

            //Assert
            Assert.Equal(rotation, leftArm.Wrist.Rotation);
        }

        [Theory]
        [InlineData(Contracted.Rest)]
        [InlineData(Contracted.SlightlyContracted)]
        [InlineData(Contracted.Contracted)]
        public void MovementWrist_WithElbowDifferentThanStronglyContracted_ShouldMovementTheWrist(Contracted contracted)
        {
            //Arrange
            var leftArm = new LeftArm();
            leftArm.Elbow.setContracted(contracted);

            //Act
            leftArm.MovementWrist(Rotation.Plus135);

            //Assert
            Assert.Equal(Rotation.Rest, leftArm.Wrist.Rotation);
        }
    }
}