﻿using Moq.AutoMock;
using Robo.Domain.Enums;
using Robo.Domain.Models;
using Robo.Domain.Services;

namespace Robo.Domain.Test.Services
{
    public class HeadServiceTest
    {
        private readonly AutoMocker _autoMocker;

        public HeadServiceTest()
        {
            _autoMocker = new AutoMocker();
        }

        [Fact]
        public void CreateHead_ShouldCreateAndReturnHead()
        {
            //Arrange
            var headService = _autoMocker.CreateInstance<HeadService>();

            //Act
            var result = headService.CreateHead();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Head>(result);
        }

        [Fact]
        public void PutRotation_ShouldSetTheNewRotationAndReturnHead()
        {
            //Arrange
            var head = new Head();
            var rotation = Rotation.Minus45;
            var headService = _autoMocker.CreateInstance<HeadService>();

            //Act
            var result = headService.PutRotation(head, rotation);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Head>(result);
            Assert.Equal(rotation, result.Rotation);
        }

        [Fact]
        public void PutSlope_ShouldSetTheNewSlopeAndReturnHead()
        {
            //Arrange
            var head = new Head();
            var headService = _autoMocker.CreateInstance<HeadService>();

            //Act
            var result = headService.PutSlope(head, Slope.Down);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Head>(result);
            Assert.Equal(Slope.Down, result.Slope);
        }
    }
}