using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.AutoMock;
using Robo.Api.Controllers;
using Robo.Api.Models;
using Robo.Domain.Enums;
using Robo.Domain.Interfaces;
using Robo.Domain.Models;

namespace Robo.Api.Test.Controllers
{
    public class LeftArmControllerTests
    {
        private readonly AutoMocker _autoMocker;

        public LeftArmControllerTests()
        {
            _autoMocker = new AutoMocker();
        }

        [Fact]
        public void PutElbowContraction_SetNewContraction_ShouldReturnLeftArmViewModelWithNewElbowContraction()
        {
            //Arrange
            var leftArm = new LeftArm();
            var contraction = Contraction.SlightlyContracted;
            var leftArmViewModel = new LeftArmViewModel();

            _autoMocker
                .GetMock<IMapper>()
                .Setup(x => x.Map<LeftArm>(It.IsAny<LeftArmViewModel>()))
                .Returns(leftArm);

            _autoMocker
                .GetMock<IMapper>()
                .Setup(x => x.Map<LeftArmViewModel>(It.IsAny<LeftArm>()))
                .Returns(leftArmViewModel);

            _autoMocker
                .GetMock<ILeftArmService>()
                .Setup(x => x.ElbowUpdateContraction(It.IsAny<LeftArm>(), It.IsAny<Contraction>()))
                .Returns(leftArm);

            var leftArmController = _autoMocker.CreateInstance<LeftArmController>();

            //Act
            var result = leftArmController.PutElbowContraction(leftArmViewModel, contraction) as OkObjectResult;

            //Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.NotNull(result);
            Assert.IsType<LeftArmViewModel>(result.Value);
        }

        [Fact]
        public void PutWristRotation_SetNewRotation_ShouldReturnLeftArmViewModelWithNewWristRotation()
        {
            //Arrange
            var leftArm = new LeftArm();
            var rotation = ArmRotation.Minus45;
            var leftArmViewModel = new LeftArmViewModel();

            _autoMocker
                .GetMock<IMapper>()
                .Setup(x => x.Map<LeftArm>(It.IsAny<LeftArmViewModel>()))
                .Returns(leftArm);

            _autoMocker
                .GetMock<IMapper>()
                .Setup(x => x.Map<LeftArmViewModel>(It.IsAny<LeftArm>()))
                .Returns(leftArmViewModel);

            _autoMocker
                .GetMock<ILeftArmService>()
                .Setup(x => x.ElbowUpdateContraction(It.IsAny<LeftArm>(), It.IsAny<Contraction>()))
                .Returns(leftArm);

            var leftArmController = _autoMocker.CreateInstance<LeftArmController>();

            //Act
            var result = leftArmController.PutWristRotation(leftArmViewModel, rotation) as OkObjectResult;

            //Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.NotNull(result);
            Assert.IsType<LeftArmViewModel>(result.Value);
        }
    }
}