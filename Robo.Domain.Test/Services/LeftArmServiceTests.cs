using Moq.AutoMock;
using Robo.Domain.Enums;
using Robo.Domain.Models;
using Robo.Domain.Services;

namespace Robo.Domain.Test.Services
{
    public class LeftArmServiceTests
    {
        private readonly AutoMocker _autoMocker;

        public LeftArmServiceTests()
        {
            _autoMocker = new AutoMocker();
        }

        [Fact]
        public void ElbowUpdateContraction_ShouldSetTheNewElbowContractionAndReturnLeftArm()
        {
            //Arrange
            var leftArm = new LeftArm();
            var contraction = Contraction.SlightlyContracted;
            var leftArmService = _autoMocker.CreateInstance<LeftArmService>();

            //Act
            var result = leftArmService.ElbowUpdateContraction(leftArm, contraction);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<LeftArm>(result);
            Assert.Equal(contraction, result.Elbow.Contraction);
        }

        [Fact]
        public void WristUpdateRotation_ShouldSetTheNewWristRotationAndReturnLeftArm()
        {
            //Arrange
            var leftArm = new LeftArm();
            leftArm.Elbow.setContraction(Contraction.StronglyContracted);
            var rotation = ArmRotation.Plus45;
            var leftArmService = _autoMocker.CreateInstance<LeftArmService>();

            //Act
            var result = leftArmService.WristUpdateRotation(leftArm, rotation);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<LeftArm>(result);
            Assert.Equal(rotation, result.Wrist.ArmRotation);
        }
    }
}