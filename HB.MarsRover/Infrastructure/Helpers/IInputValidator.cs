using System;
using System.Collections.Generic;
using System.Text;

namespace HB.MarsRover.Infrastructure.Helpers
{
    public interface IInputValidator
    {
        bool IsUpperRightCoordinatesValid(string command);
        bool IsRoverPositionValid(string command, int upperRightX, int upperRightY);
        bool IsCommandValid(string command);
    }
}
