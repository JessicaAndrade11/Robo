using Robo.Domain.Enums;
using Robo.Domain.Models;

namespace Robo.Domain.Test
{
    public class HeadTests
    {
        [Fact]
        public void Head_InitialState_ShouldBeRest()
        {
            //Arrange

            //Act
            var result = new Head();

            //Assert
            Assert.Equal(Slope.Rest, result.Slope);
            Assert.Equal(Rotation.Rest, result.Rotation);
        }
    }
}