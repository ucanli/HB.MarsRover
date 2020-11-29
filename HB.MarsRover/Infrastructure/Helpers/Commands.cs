using HB.MarsRover.Domain.Entities;
using HB.MarsRover.Infrastructure.Enums;

namespace HB.MarsRover.Infrastructure.Helpers
{
    public static class Commands
    {
        public static void Move(Position position)
        {
            switch (position.HeadingDirection)
            {
                case RoverDirection.N:
                    position.PositionY += 1;
                    break;
                case RoverDirection.S:
                    position.PositionY -= 1;
                    break;
                case RoverDirection.E:
                    position.PositionX += 1;
                    break;
                case RoverDirection.W:
                    position.PositionX -= 1;
                    break;
                default:
                    break;
            }
        }

        public static void Left(Position position)
        {
            switch (position.HeadingDirection)
            {
                case RoverDirection.N:
                    position.HeadingDirection = RoverDirection.W;
                    break;
                case RoverDirection.S:
                    position.HeadingDirection = RoverDirection.E;
                    break;
                case RoverDirection.E:
                    position.HeadingDirection = RoverDirection.N;
                    break;
                case RoverDirection.W:
                    position.HeadingDirection = RoverDirection.S;
                    break;
                default:
                    break;
            }
        }

        public static void Right(Position position)
        {
            switch (position.HeadingDirection)
            {
                case RoverDirection.N:
                    position.HeadingDirection = RoverDirection.E;
                    break;
                case RoverDirection.S:
                    position.HeadingDirection = RoverDirection.W;
                    break;
                case RoverDirection.E:
                    position.HeadingDirection = RoverDirection.S;
                    break;
                case RoverDirection.W:
                    position.HeadingDirection = RoverDirection.N;
                    break;
                default:
                    break;
            }
        }
    }
}
