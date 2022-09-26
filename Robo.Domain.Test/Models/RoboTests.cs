namespace Robo.Domain.Test.Models
{
    public class RoboTests
    {
        [Fact]
        public void Constructor_ShouldCreateRobo()
        {
            //Arrange

            //Act
            var result = new Domain.Models.RoboUnit();

            //Assert
            Assert.NotNull(result);
        }
    }
}