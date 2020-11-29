using HB.MarsRover.Infrastructure.Helpers;
using HB.MarsRover.Infrastructure.Statics;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using HB.MarsRover.Domain.Entities;
using HB.MarsRover.Infrastructure.Enums;
using System.Linq;
using EasyConsoleCore;

namespace HB.MarsRover.Application.Services
{
    public class RoverService : IRoverService
    {
        private readonly IInputValidator _inputValidator;

        public RoverService(IInputValidator inputValidator)
        {
            _inputValidator = inputValidator;
        }
        /// <summary>
        /// Initialize inputs from console, then do calculations.
        /// </summary>
        public void InitilazeInputsAndCalculate()
        {
            var plateau = new Plateau();
            #region Plateau Size
            var isUpperRightCoordinatesValid = false;
            string upperRightCoordinatesInput = "";
            while (!isUpperRightCoordinatesValid)
            {
                Output.WriteLine(ConsoleColor.Yellow, UserFirendlyMessages.ENTER_UPPER_RIGHT_COORDINATES);
                upperRightCoordinatesInput = Console.ReadLine();

                isUpperRightCoordinatesValid = _inputValidator.IsUpperRightCoordinatesValid(upperRightCoordinatesInput);

                if (!isUpperRightCoordinatesValid)
                {
                    Output.WriteLine(ConsoleColor.Red, UserFirendlyMessages.UPPER_RIGHT_COORDINATES_NOT_VALID);
                }
            }

            var upperRightCoordinates = Regex.Replace(upperRightCoordinatesInput.Trim(), @"\s+", " ").Split(" ");
            var upperRightX = int.Parse(upperRightCoordinates[0]);
            var upperRightY = int.Parse(upperRightCoordinates[1]);

            plateau.UpperRightCoordinateX = upperRightX;
            plateau.UpperRightCoordinateY = upperRightY;
            #endregion

            var addRover = true;
            var roverList = new List<Rover>();
            var order = 1;
            while (addRover)
            {
                #region Validate Position
                string positionInput = "";
                var isPositionValid = false;
                while (!isPositionValid)
                {
                    Output.WriteLine(ConsoleColor.Yellow, UserFirendlyMessages.ENTER_POSITION);
                    positionInput = Console.ReadLine();
                    isPositionValid = _inputValidator.IsRoverPositionValid(positionInput, upperRightX, upperRightY);

                    if (!isPositionValid)
                    {
                        Output.WriteLine(ConsoleColor.Red, UserFirendlyMessages.POSITION_NOT_VALID);
                    }
                }
                #endregion

                #region Validate Command
                var isCommandValid = false;
                var commandInput = "";
                while (!isCommandValid)
                {
                    Output.WriteLine(ConsoleColor.Yellow, UserFirendlyMessages.ENTER_COMMAND_ROVER);
                    commandInput = Console.ReadLine();
                    isCommandValid = _inputValidator.IsCommandValid(commandInput);
                    if (!isCommandValid)
                    {
                        Output.WriteLine(ConsoleColor.Red, UserFirendlyMessages.COMMAND_NOT_VALID);
                    }
                }
                #endregion

                #region Create Rover

                var roverPosition = GetPositionByInputString(positionInput);

                roverList.Add(new Rover()
                {
                    Order = order,
                    Position = roverPosition,
                    Command = commandInput.Trim().ToUpper()
                });

                #endregion

                var addRoverMenu = new EasyConsoleCore.Menu()
                    .Add("Add one more rover", () => addRover = true)
                    .Add("Continue", () => addRover = false);
                addRoverMenu.Display();
                order++;
            }
            plateau.Rovers = roverList;

            CalculateMovements(plateau);
            DisplayOutputs(plateau);

            Console.ReadLine();
        }

        public Position GetPositionByInputString(string positionInput)
        {
            var position = Regex.Replace(positionInput.Trim(), @"\s+", " ").Split(" ");
            var positionX = int.Parse(position[0]);
            var positionY = int.Parse(position[1]);
            var headingDirection = position[2];

            var roverPosition = new Position();
            roverPosition.PositionX = positionX;
            roverPosition.PositionY = positionY;
            roverPosition.HeadingDirection = (RoverDirection)Enum.Parse(typeof(RoverDirection), headingDirection.ToUpper());

            return roverPosition;
        }


        /// <summary>
        /// Run commands and calculate final positions
        /// </summary>
        /// <param name="plateau"></param>
        public void CalculateMovements(Plateau plateau)
        {
            plateau.Rovers = plateau.Rovers.OrderBy(x => x.Order).ToList();
            foreach (var rover in plateau.Rovers)
            {
                foreach (var command in rover.Command)
                {
                    switch (command)
                    {
                        case 'M':
                            Commands.Move(rover.Position);
                            break;
                        case 'L':
                            Commands.Left(rover.Position);
                            break;
                        case 'R':
                            Commands.Right(rover.Position);
                            break;
                        default:
                            break;
                    }

                    if (rover.Position.PositionX > plateau.UpperRightCoordinateX || rover.Position.PositionX < 0 || rover.Position.PositionY > plateau.UpperRightCoordinateY || rover.Position.PositionY < 0)
                    {
                        rover.Position.IsPositionOutOfPlateauSize = true;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// To display outputs in console
        /// </summary>
        /// <param name="plateau"></param>
        public void DisplayOutputs(Plateau plateau)
        {

            Output.WriteLine(ConsoleColor.Green, UserFirendlyMessages.OUTPUTS);
            foreach (var rover in plateau.Rovers)
            {
                if (rover.Position.IsPositionOutOfPlateauSize)
                {
                    Output.WriteLine(ConsoleColor.Red, $"Rover went out of plateau size at {rover.Position.PositionX} {rover.Position.PositionY} {rover.Position.HeadingDirection}");
                    continue;
                }

                var checkIfAnyRoverHadSamePositionBefore = plateau.Rovers.Any(x => x.Order < rover.Order && x.Position.PositionX == rover.Position.PositionX && x.Position.PositionY == rover.Position.PositionY);

                if (checkIfAnyRoverHadSamePositionBefore)
                {
                    Output.WriteLine(ConsoleColor.Red, $"{rover.Position.PositionX} {rover.Position.PositionY} {rover.Position.HeadingDirection} Another rover went to same position before, possible crash!");
                    continue;
                }

                Output.WriteLine(ConsoleColor.Blue, $"{rover.Position.PositionX} {rover.Position.PositionY} {rover.Position.HeadingDirection}");

            }
        }
    }
}
