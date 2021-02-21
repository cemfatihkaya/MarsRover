using FluentAssertions;
using MarsRover.Business.Services;
using MarsRover.Model;
using NUnit.Framework;

namespace MarsRover.Tests.Business
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class RoverServiceTests : BaseTestFixture
    {
        #region members & setup

        [SetUp]
        public void Initialize()
        {
        }

        #endregion

        #region verify mocks

        protected override void VerifyMocks()
        {
        }

        #endregion

        [Test]
        public void Process_FirstInput_ReturnExpectedResult()
        {
            //Arrange
            var plateauOne = new Plateau(new Position(5, 5));
            var roverService = new RoverService(plateauOne, new Position(1, 2), Directions.N);

            //Act
            roverService.Process("LMLMLMLMM");

            //Assert
            var expectedResult = roverService.Print();
            expectedResult.Should().Be("1 3 N");
        }

        [Test]
        public void Process_SecondInput_ReturnExpectedResult()
        {
            //Arrange
            var plateauOne = new Plateau(new Position(5, 5));
            var roverService = new RoverService(plateauOne, new Position(3, 3), Directions.E);

            //Act
            roverService.Process("MMRMMRMRRM");

            //Assert
            var expectedResult = roverService.Print();
            expectedResult.Should().Be("5 1 E");
        }
    }
}