using HB.MarsRover.Infrastructure.Helpers;
using Xunit;

namespace HB.MarsRover.Test
{
    [Trait("Helpers", "InputValidator")]

    public class InputValidatorTest : IClassFixture<InputValidator>
    {
        private readonly InputValidator _sut;
        public InputValidatorTest(InputValidator sut)
        {
            _sut = sut;
        }

        [Theory]
        [InlineData(new object[] { "5 5", true})]
        [InlineData(new object[] { "5   5", true })]
        [InlineData(new object[] { "0 5", false })]
        [InlineData(new object[] { "5 0", false })]
        [InlineData(new object[] { "-1 5", false })]
        [InlineData(new object[] { "A 5", false })]
        [InlineData(new object[] { "5 5 X", false })]

        public void ValidateUpperRightCoordinates(
            string command,
            bool expectedResult)
        { 
            var isValid = _sut.IsUpperRightCoordinatesValid(command);

            Assert.Equal(expectedResult, isValid);
        }

        [Theory]
        [InlineData(new object[] { "1 2 N",5,5, true })]
        [InlineData(new object[] { "3 3 N",5,5, true })]
        [InlineData(new object[] { "6 6 N",5,5, false })]
        [InlineData(new object[] { "-6 6 N",5,5, false })]
        [InlineData(new object[] { "1 2 X",5,5, false })]
        public void ValidateRoverPosition(
            string command,
            int upperRightX, 
            int upperRightY,
            bool expectedResult)
        {
            var isValid = _sut.IsRoverPositionValid(command, upperRightX, upperRightY);

            Assert.Equal(expectedResult, isValid);
        }

        [Theory]
        [InlineData(new object[] { "LMLMLMLMM", true })]
        [InlineData(new object[] { "MMRMMRMRRM", true })]
        [InlineData(new object[] { "XRRM", false })]
        [InlineData(new object[] { "LM 1", false })]
        public void ValidateRoverCommand(
            string command,
            bool expectedResult)
        {
            var isValid = _sut.IsCommandValid(command);

            Assert.Equal(expectedResult, isValid);
        }
    }
}
