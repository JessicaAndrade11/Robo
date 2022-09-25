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
    public class HeadControllerTests
    {
        private readonly AutoMocker _autoMocker;

        public HeadControllerTests()
        {
            _autoMocker = new AutoMocker();
        }

        [Fact]
        public void PostRotation_ShouldCreateHeadAndReturnHeadViewModel()
        {
            //Arrange
            var head = new Head();
            var headViewModel = new HeadViewModel();

            _autoMocker
                .GetMock<IMapper>()
                .Setup(x => x.Map<HeadViewModel>(It.IsAny<Head>()))
                .Returns(headViewModel);

            _autoMocker
                .GetMock<IHeadService>()
                .Setup(x => x.CreateHead())
                .Returns(head);

            var headController = _autoMocker.CreateInstance<HeadController>();

            //Act
            var result = headController.PostCreateHead() as OkObjectResult;

            //Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.NotNull(result);
            Assert.IsType<HeadViewModel>(result.Value);
        }

        [Fact]
        public void PutRotation_SetNewRotation_ShouldReturnHeadViewModelWithNewRotation()
        {
            //Arrange
            var head = new Head();
            var rotation = HeadRotation.Plus90;
            var headViewModel = new HeadViewModel();

            _autoMocker
                .GetMock<IMapper>()
                .Setup(x => x.Map<HeadViewModel>(It.IsAny<Head>()))
                .Returns(headViewModel);

            _autoMocker
                .GetMock<IHeadService>()
                .Setup(x => x.PutRotation(It.IsAny<Head>(), It.IsAny<HeadRotation>()))
                .Returns(head);

            var headController = _autoMocker.CreateInstance<HeadController>();

            //Act
            var result = headController.PutRotation(head, rotation) as OkObjectResult;

            //Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.NotNull(result);
            Assert.IsType<HeadViewModel>(result.Value);
        }

        [Fact]
        public void PutTilt_SetNewTilt_ShouldReturnHeadViewModelWithNewTilt()
        {
            //Arrange
            var head = new Head();
            var tilt = Tilt.Up;
            var headViewModel = new HeadViewModel();

            _autoMocker
                .GetMock<IMapper>()
                .Setup(x => x.Map<HeadViewModel>(It.IsAny<Head>()))
                .Returns(headViewModel);

            _autoMocker
                .GetMock<IHeadService>()
                .Setup(x => x.PutTilt(It.IsAny<Head>(), It.IsAny<Tilt>()))
                .Returns(head);

            var headController = _autoMocker.CreateInstance<HeadController>();

            //Act
            var result = headController.PutTilt(head, tilt) as OkObjectResult;

            //Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.NotNull(result);
            Assert.IsType<HeadViewModel>(result.Value);
        }
    }
}