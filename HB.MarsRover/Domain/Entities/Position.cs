
using HB.MarsRover.Infrastructure.Enums;

namespace HB.MarsRover.Domain.Entities
{
    public class Position
    {
        public Position()
        {
            IsPositionOutOfPlateauSize = false;
        }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public RoverDirection HeadingDirection { get; set; }
        public bool IsPositionOutOfPlateauSize { get; set; }
    }
}
