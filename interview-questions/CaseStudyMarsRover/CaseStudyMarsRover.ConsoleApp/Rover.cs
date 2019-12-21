using System;
using System.Linq;

namespace CaseStudyMarsRover.ConsoleApp
{
    public class Rover
    {
        public Coordinate Coordinate { get; set; }

        private string _roverOrientation;
        public string RoverOrientation
        {
            get => _roverOrientation;
            set
            {
                value = value.ToLower();
                if (!ApplicationConstants.PreDefinedOrientations.Contains(value))
                {
                    throw new Exception("Unidentified orientation!");
                }

                _roverOrientation = value;
            }
        }

        private string _instructions;
        public string Instructions
        {
            get => _instructions;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    value = value.ToLower();
                    if (value.Any(instruction => !ApplicationConstants.PreDefinedInstructions.Contains((char)instruction)))
                    {
                        throw new Exception("Invalid instructions!");
                    }
                }

                _instructions = value;
            }
        }

        public Rover(Coordinate coordinate, string orientation, string instructions)
        {
            Coordinate = coordinate;
            RoverOrientation = orientation;
            Instructions = instructions;
        }

        // Clockwise rotation of array
        public void TurnLeft()
        {
            var orientationIndex = (ApplicationConstants.PreDefinedOrientations.IndexOf(RoverOrientation, StringComparison.Ordinal) - 1)
                .Mod(ApplicationConstants.PreDefinedOrientations.Length);

            RoverOrientation = ApplicationConstants.PreDefinedOrientations[orientationIndex].ToString();
        }

        // Counter-clockwise rotation of array
        public void TurnRight()
        {
            var orientationIndex = ApplicationConstants.PreDefinedOrientations.IndexOf(RoverOrientation, StringComparison.Ordinal)
                .Mod(ApplicationConstants.PreDefinedOrientations.Length);

            RoverOrientation = ApplicationConstants.PreDefinedOrientations[orientationIndex].ToString();
        }

        public void Move(Size plateauSize)
        {
            switch (RoverOrientation)
            {
                case "w":
                    Coordinate.CoordinateX--;
                    break;
                case "n":
                    Coordinate.CoordinateY++;
                    break;
                case "e":
                    Coordinate.CoordinateX++;
                    break;
                default:
                    Coordinate.CoordinateY--;
                    break;
            }

            if (Coordinate.CoordinateX > plateauSize.Width ||
                Coordinate.CoordinateY > plateauSize.Height)
            {
                throw new Exception("Invalid movement for rover!");
            }
        }
    }
}