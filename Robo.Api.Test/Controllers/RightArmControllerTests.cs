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
    public class RightArmControllerTests
    {
        private readonly AutoMocker _autoMocker;

        public RightArmControllerTests()
        {
            _autoMocker = new AutoMocker();
        }

        [Fact]
        public void PutElbowContraction_SetNewContraction_ShouldReturnRightArmViewModelWithNewElbowContraction()
        {
            //Arrange
            var rightArm = new RightArm();
            var contraction = Contraction.SlightlyContracted;
            var rightArmViewModel = new RightArmViewModel();

            _autoMocker
                .GetMock<IMapper>()
                .Setup(x => x.Map<RightArm>(It.IsAny<RightArmViewModel>()))
                .Returns(rightArm);

            _autoMocker
                .GetMock<IMapper>()
                .Setup(x => x.Map<RightArmViewModel>(It.IsAny<RightArm>()))
                .Returns(rightArmViewModel);

            _autoMocker
                .GetMock<IRightArmService>()
                .Setup(x => x.ElbowUpdateContraction(It.IsAny<RightArm>(), It.IsAny<Contraction>()))
                .Returns(rightArm);

            var rightArmController = _autoMocker.CreateInstance<RightArmController>();

            //Act
            var result = rightArmController.PutElbowContraction(rightArmViewModel, contraction) as OkObjectResult;

            //Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.NotNull(result);
            Assert.IsType<RightArmViewModel>(result.Value);
        }

        [Fact]
        public void PutWristRotation_SetNewRotation_ShouldReturnRightArmViewModelWithNewWristRotation()
        {
            //Arrange
            var rightArm = new RightArm();
            var rotation = ArmRotation.Minus45;
            var rightArmViewModel = new RightArmViewModel();

            _autoMocker
                .GetMock<IMapper>()
                .Setup(x => x.Map<RightArm>(It.IsAny<RightArmViewModel>()))
                .Returns(rightArm);

            _autoMocker
                .GetMock<IMapper>()
                .Setup(x => x.Map<RightArmViewModel>(It.IsAny<RightArm>()))
                .Returns(rightArmViewModel);

            _autoMocker
                .GetMock<IRightArmService>()
                .Setup(x => x.ElbowUpdateContraction(It.IsAny<RightArm>(), It.IsAny<Contraction>()))
                .Returns(rightArm);

            var rightArmController = _autoMocker.CreateInstance<RightArmController>();

            //Act
            var result = rightArmController.PutWristRotation(rightArmViewModel, rotation) as OkObjectResult;

            //Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.NotNull(result);
            Assert.IsType<RightArmViewModel>(result.Value);
        }
    }
}