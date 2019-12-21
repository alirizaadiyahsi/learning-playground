using System;
using System.Collections.Generic;

namespace CaseStudyMarsRover.ConsoleApp
{
    public class Program
    {
        public static void Main()
        {
            var plateauSize = ReadPlateauSize();
            var rovers = ReadRovers();

            SetRoversLastPosition(plateauSize, rovers);
        }

        private static IEnumerable<Rover> ReadRovers()
        {
            var rovers = new List<Rover>();
            while (true)
            {
                Console.WriteLine("Please specify rover info! E.g => 1 3 N");
                var roverStringsLine = Console.ReadLine();
                if (string.IsNullOrEmpty(roverStringsLine))
                {
                    break;
                }

                var roverStrings = roverStringsLine.Split(' ');
                if (roverStrings.Length > 3)
                {
                    throw new Exception("Invalid parameter count!");
                }

                Console.WriteLine("Please specify instructions! E.g => LMLMLMLMM");
                var instructionsString = Console.ReadLine();

                if (string.IsNullOrEmpty(instructionsString))
                {
                    continue;
                }

                rovers.Add(new Rover(
                    new Coordinate(int.Parse(roverStrings[0]), int.Parse(roverStrings[1])),
                    roverStrings[2],
                    instructionsString
                ));
            }

            return rovers;
        }

        private static Size ReadPlateauSize()
        {
            Size plateauSize;
            Console.WriteLine("Please specify plateau sizes! E.g => 5 5");
            var plateauSizesStringLine = Console.ReadLine();
            while (string.IsNullOrEmpty(plateauSizesStringLine))
            {
                Console.WriteLine("Please specify plateau sizes! E.g => 5 5");
                plateauSizesStringLine = Console.ReadLine();
            }

            var plateauSizesString = plateauSizesStringLine.Split(' ');
            if (plateauSizesString != null && plateauSizesString.Length > 1)
            {
                plateauSize = new Size(
                    int.Parse(plateauSizesString[0]),
                    int.Parse(plateauSizesString[1])
                );
            }
            else
            {
                throw new Exception("Invalid parameters count!");
            }

            return plateauSize;
        }

        public static void SetRoversLastPosition(Size plateauSize, IEnumerable<Rover> rovers)
        {
            Console.WriteLine("Results:");
            foreach (var rover in rovers)
            {
                if (rover.Coordinate.CoordinateX > plateauSize.Width ||
                    rover.Coordinate.CoordinateY > plateauSize.Height)
                {
                    throw new Exception("Invalid position for rover!");
                }

                foreach (var instruction in rover.Instructions)
                {
                    if (instruction == 'l')
                    {
                        rover.TurnLeft();
                    }
                    else if (instruction == 'r')
                    {
                        rover.TurnRight();
                    }
                    else
                    {
                        rover.Move(plateauSize);
                    }
                }

                Console.WriteLine($"{rover.Coordinate.CoordinateX} {rover.Coordinate.CoordinateY} {rover.RoverOrientation}");
            }
        }
    }
}
