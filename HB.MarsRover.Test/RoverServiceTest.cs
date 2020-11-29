using HB.MarsRover.Application.Services;
using HB.MarsRover.Domain.Entities;
using HB.MarsRover.Infrastructure.Helpers;
using Moq;
using System.Linq;
using Xunit;

namespace HB.MarsRover.Test
{
    [Trait("ApplicationService", "RoverService")]

    public class RoverServiceTest
    {
        private readonly RoverService _sut;
        private readonly Mock<IInputValidator> _mockedInputValidator;

        public RoverServiceTest()
        {
            _mockedInputValidator = new Mock<IInputValidator>();
            _sut = new RoverService(_mockedInputValidator.Object);
        }


        [Theory]
        [InlineData(new object[] { 5, 5, new string[] { "1 2 N", "3 3 E" }, new string[] { "LMLMLMLMM", "MMRMMRMRRM" }, new string[] { "1 3 N", "5 1 E" } })]

        public void ValidateUpperRightCoordinates(
             int upperRightX,
             int upperRightY,
             string[] positions,
             string[] commands,
             string[] expectedResults)
        {
            var plateau = new Plateau();
            plateau.UpperRightCoordinateX = upperRightX;
            plateau.UpperRightCoordinateY = upperRightY;

            plateau.Rovers = positions.Select((v, i) => new Rover()
            {
                Command = commands[i],
                Order = i,
                Position = _sut.GetPositionByInputString(positions[i].ToUpper())
            }).ToList();

            _sut.CalculateMovements(plateau);

            for (int i = 0; i < plateau.Rovers.Count; i++)
            {
                var rover = plateau.Rovers[i];
                Assert.Equal(expectedResults[i], $"{rover.Position.PositionX} {rover.Position.PositionY} {rover.Position.HeadingDirection}");
            }
        }
    }
}
