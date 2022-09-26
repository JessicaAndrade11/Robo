using Moq.AutoMock;
using Robo.Domain.Enums;
using Robo.Domain.Models;
using Robo.Domain.Services;

namespace Robo.Domain.Test.Services
{
    public class RightArmServiceTests
    {
        private readonly AutoMocker _autoMocker;

        public RightArmServiceTests()
        {
            _autoMocker = new AutoMocker();
        }

        [Fact]
        public void ElbowUpdateContraction_ShouldSetTheNewElbowContractionAndReturnRightArm()
        {
            //Arrange
            var rightArm = new RightArm();
            var contraction = Contraction.SlightlyContracted;
            var rightArmService = _autoMocker.CreateInstance<RightArmService>();

            //Act
            var result = rightArmService.ElbowUpdateContraction(rightArm, contraction);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<RightArm>(result);
            Assert.Equal(contraction, result.Elbow.Contraction);
        }

        [Fact]
        public void WristUpdateRotation_ShouldSetTheNewWristRotationAndReturnRightArm()
        {
            //Arrange
            var rightArm = new RightArm();
            rightArm.Elbow.setContraction(Contraction.StronglyContracted);
            var rotation = ArmRotation.Plus45;
            var rightArmService = _autoMocker.CreateInstance<RightArmService>();

            //Act
            var result = rightArmService.WristUpdateRotation(rightArm, rotation);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<RightArm>(result);
            Assert.Equal(rotation, result.Wrist.ArmRotation);
        }
    }
}