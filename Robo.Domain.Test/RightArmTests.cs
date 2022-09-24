using Robo.Domain.Enums;
using Robo.Domain.Models;

namespace Robo.Domain.Test
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
    }
}