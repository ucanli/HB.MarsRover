
namespace HB.MarsRover.Infrastructure.Statics
{
    public static class RegexesForInputs
    {
        public const string UPPER_RIGHT_COORDINATES = @"^[1-9]\d* \s*[1-9]\d*$";
        public const string ROVER_POSITION = @"^[0-9]\d* \s*[0-9]\d* \s*[NSEW]$";
        public const string COMMAND = "^[LRM]+$";
    }
}
