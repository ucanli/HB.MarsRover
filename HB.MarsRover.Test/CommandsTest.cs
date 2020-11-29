using HB.MarsRover.Domain.Entities;
using HB.MarsRover.Infrastructure.Enums;
using HB.MarsRover.Infrastructure.Helpers;
using Xunit;

namespace HB.MarsRover.Test
{
    [Trait("Helpers","Commands")]
    public class CommandsTest
    {

        [Theory]
        [InlineData(new object[] { 5, 5, RoverDirection.E, 6, 5, RoverDirection.E })]
        [InlineData(new object[] { 5, 5, RoverDirection.N, 5, 6, RoverDirection.N })]
        [InlineData(new object[] { 5, 5, RoverDirection.W, 4, 5, RoverDirection.W })]
        [InlineData(new object[] { 5, 5, RoverDirection.S, 5, 4, RoverDirection.S })]

        public void GeneratePositionAndMoveCommand(
            int positionX,
            int positionY,
            RoverDirection roverDirection,
            int expectedX,
            int expectedY,
            RoverDirection expectedRoverDirection)
        {
            var position = new Position()
            {
                PositionX = positionX,
                PositionY = positionY,
                HeadingDirection = roverDirection
            };

            Commands.Move(position);

            Assert.NotNull(position);
            Assert.Equal(expectedX, position.PositionX);
            Assert.Equal(expectedY, position.PositionY);
            Assert.Equal(expectedRoverDirection, position.HeadingDirection);
        }


        [Theory]
        [InlineData(new object[] { 5, 5, RoverDirection.E, 5, 5, RoverDirection.N })]
        [InlineData(new object[] { 5, 5, RoverDirection.N, 5, 5, RoverDirection.W })]
        [InlineData(new object[] { 5, 5, RoverDirection.W, 5, 5, RoverDirection.S })]
        [InlineData(new object[] { 5, 5, RoverDirection.S, 5, 5, RoverDirection.E })]
        public void GeneratePositionAndLeftCommand(
            int positionX,
            int positionY,
            RoverDirection roverDirection,
            int expectedX,
            int expectedY,
            RoverDirection expectedRoverDirection)
        {
            var position = new Position()
            {
                PositionX = positionX,
                PositionY = positionY,
                HeadingDirection = roverDirection
            };

            Commands.Left(position);

            Assert.NotNull(position);
            Assert.Equal(expectedX, position.PositionX);
            Assert.Equal(expectedY, position.PositionY);
            Assert.Equal(expectedRoverDirection, position.HeadingDirection);
        }

        [Theory]
        [InlineData(new object[] { 5, 5, RoverDirection.E, 5, 5, RoverDirection.S })]
        [InlineData(new object[] { 5, 5, RoverDirection.N, 5, 5, RoverDirection.E })]
        [InlineData(new object[] { 5, 5, RoverDirection.W, 5, 5, RoverDirection.N })]
        [InlineData(new object[] { 5, 5, RoverDirection.S, 5, 5, RoverDirection.W })]

        public void GeneratePositionAndRightCommand(
            int positionX,
            int positionY,
            RoverDirection roverDirection,
            int expectedX,
            int expectedY,
            RoverDirection expectedRoverDirection)
        {
            var position = new Position()
            {
                PositionX = positionX,
                PositionY = positionY,
                HeadingDirection = roverDirection
            };

            Commands.Right(position);

            Assert.NotNull(position);
            Assert.Equal(expectedX, position.PositionX);
            Assert.Equal(expectedY, position.PositionY);
            Assert.Equal(expectedRoverDirection, position.HeadingDirection);
        }

    }
}
