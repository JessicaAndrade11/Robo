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
            var rightArm = new RightArm();
            rightArm.Elbow.setContracted(Contracted.StronglyContracted);

            //Act
            rightArm.MovementWrist(rotation);

            //Assert
            Assert.Equal(rotation, rightArm.Wrist.Rotation);
        }

        [Theory]
        [InlineData(Contracted.Rest)]
        [InlineData(Contracted.SlightlyContracted)]
        [InlineData(Contracted.Contracted)]
        public void MovementWrist_WithElbowDifferentThanStronglyContracted_ShouldMovementTheWrist(Contracted contracted)
        {
            //Arrange
            var rightArm = new RightArm();
            rightArm.Elbow.setContracted(contracted);

            //Act
            rightArm.MovementWrist(Rotation.Plus135);

            //Assert
            Assert.Equal(Rotation.Rest, rightArm.Wrist.Rotation);
        }
    }
}