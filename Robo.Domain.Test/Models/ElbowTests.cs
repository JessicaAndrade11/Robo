using Robo.Domain.Enums;
using Robo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robo.Domain.Test.Models
{
    public class ElbowTests
    {
        [Fact]
        public void Elbow_InitialState_ShouldBeRest()
        {
            //Arrange

            //Act
            var result = new Elbow();

            //Assert
            Assert.Equal(Contraction.Rest, result.Contraction);
        }

        [Theory]
        [InlineData(Contraction.Rest, Contraction.SlightlyContracted)]
        [InlineData(Contraction.SlightlyContracted, Contraction.Contracted)]
        [InlineData(Contraction.SlightlyContracted, Contraction.Rest)]
        [InlineData(Contraction.StronglyContracted, Contraction.Contracted)]
        public void SetContracted_ShouldContractTheElbow(Contraction currentContraction, Contraction newContraction)
        {
            //Arrange
            var elbow = new Elbow();
            elbow.setContraction(currentContraction);

            //Act
            elbow.setContraction(newContraction);

            //Assert
            Assert.Equal(newContraction, elbow.Contraction);
        }

        [Fact]
        public void SetContraction_JumpAState_ShouldNotContractedTheElbow()
        {
            //Arrange
            var elbow = new Elbow();

            //Act
            //Assert
            var exception = Assert.Throws<Exception>(() => elbow.setContraction(Contraction.Contracted));
            Assert.Equal("You can't contract the elbow, because it`s jump a state", exception.Message);
        }
    }
}
