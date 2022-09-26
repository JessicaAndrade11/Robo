using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.AutoMock;
using Robo.Api.Controllers;
using Robo.Api.Models;
using Robo.Domain.Interfaces;
using Robo.Domain.Models;

namespace Robo.Api.Test.Controllers
{
    public class RoboControllerTests
    {
        private readonly AutoMocker _autoMocker;

        public RoboControllerTests()
        {
            _autoMocker = new AutoMocker();
        }

        [Fact]
        public void PostRotation_ShouldCreateHeadAndReturnHeadViewModel()
        {
            //Arrange
            var robo = new RoboUnit();
            var roboViewModel = new RoboViewModel();

            _autoMocker
                .GetMock<IMapper>()
                .Setup(x => x.Map<RoboViewModel>(It.IsAny<RoboUnit>()))
                .Returns(roboViewModel);

            _autoMocker
                .GetMock<IRoboService>()
                .Setup(x => x.CreateRobo())
                .Returns(robo);

            var roboController = _autoMocker.CreateInstance<RoboController>();

            //Act
            var result = roboController.CreateRobo() as OkObjectResult;

            //Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.NotNull(result);
            Assert.IsType<RoboViewModel>(result.Value);
        }
    }
}