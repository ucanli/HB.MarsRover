using System.Collections.Generic;

namespace HB.MarsRover.Domain.Entities
{
    public class Plateau
    {
        public int UpperRightCoordinateX { get; set; }
        public int UpperRightCoordinateY { get; set; }
        public List<Rover> Rovers{ get; set; }
    }
}
