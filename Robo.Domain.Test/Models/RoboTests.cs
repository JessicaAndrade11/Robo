using Robo.Domain.Models;

namespace Robo.Domain.Test.Models
{
    public class RoboTests
    {
        [Fact]
        public void Constructor_ShouldCreateRobo()
        {
            //Arrange
            var head = new Head();
            var rightArm = new RightArm();
            var leftArm = new LeftArm();

            //Act
            var result = new Domain.Models.Robo(head, rightArm, leftArm);

            //Assert
            Assert.NotNull(result);
        }
    }
}