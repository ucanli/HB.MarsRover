using HB.MarsRover.Infrastructure.Statics;
using System.Text.RegularExpressions;

namespace HB.MarsRover.Infrastructure.Helpers
{
    public class InputValidator : IInputValidator
    {
        public bool IsUpperRightCoordinatesValid(string command)
        {
            command = command.Trim();
            Regex regexUpperRightCoordinates = new Regex(RegexesForInputs.UPPER_RIGHT_COORDINATES);

            return regexUpperRightCoordinates.IsMatch(command);
        }

        public bool IsRoverPositionValid(string command, int upperRightX, int upperRightY)
        {
            command = command.Trim();
            Regex regexRoverPosition = new Regex(RegexesForInputs.ROVER_POSITION, RegexOptions.IgnoreCase);

            if (!regexRoverPosition.IsMatch(command))
            {
                return false;
            }

            var positions = Regex.Replace(command, @"\s+", " ").Split(" ");
            var positionX = int.Parse(positions[0]);
            var positionY = int.Parse(positions[1]);

            if (positionX > upperRightX || positionY > upperRightY)
            {
                return false;
            }
            return true;
        }
        public bool IsCommandValid(string command)
        {
            command = command.Trim();
            Regex regexCommand = new Regex(RegexesForInputs.COMMAND, RegexOptions.IgnoreCase);

            return regexCommand.IsMatch(command);
        }
    }
}
