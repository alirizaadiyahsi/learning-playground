using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CaseStudyMarsRover.ConsoleApp.Tests
{
    public class ProgramTests
    {
        private Size plateauSize;
        private List<Rover> rovers;

        [SetUp]
        public void Setup()
        {
            plateauSize = new Size(5, 5);
            rovers = new List<Rover>
            {
                new Rover(new Coordinate(1, 2), "N", "LMLMLMLMM"),
                new Rover(new Coordinate(3, 3), "E", "MMRMMRMRRM")
            };
        }

        [Test]
        public void Should_Get_Correct_Coordinates()
        {
            Program.SetRoversLastPosition(plateauSize, rovers);

            Assert.AreEqual(1, rovers[0].Coordinate.CoordinateX);
            Assert.AreEqual(3, rovers[0].Coordinate.CoordinateY);
            Assert.AreEqual("n", rovers[0].RoverOrientation);

            Assert.AreEqual(5, rovers[1].Coordinate.CoordinateX);
            Assert.AreEqual(1, rovers[1].Coordinate.CoordinateY);
            Assert.AreEqual("e", rovers[1].RoverOrientation);
        }

        [Test]
        public void Should_Get_Exception_For_Incorrect_Rover_Coordinates()
        {
            var incorrectRovers = new List<Rover>
            {
                new Rover(new Coordinate(6, 3), "E", "MMRMMRMRRM")
            };
            var exception = Assert.Throws<Exception>(() => Program.SetRoversLastPosition(plateauSize, incorrectRovers));
            Assert.AreEqual("Invalid position for rover!", exception.Message);
        }

        [Test]
        public void Should_Get_Exception_For_Incorrect_Rover_Orientation()
        {
            var exception = Assert.Throws<Exception>(() =>
            {
                var incorrectRovers = new List<Rover>
                {
                    new Rover(new Coordinate(3, 3), "X", "MMRMMRMRRM")
                };
            });
            Assert.AreEqual("Unidentified orientation!", exception.Message);
        }

        [Test]
        public void Should_Get_Exception_For_Incorrect_Rover_Instructions()
        {
            var exception = Assert.Throws<Exception>(() =>
            {
                var incorrectRovers = new List<Rover>
                {
                    new Rover(new Coordinate(3, 3), "N", "ABC")
                };
            });
            Assert.AreEqual("Invalid instructions!", exception.Message);
        }

        [Test]
        public void Should_Get_Exception_For_Incorrect_Rover_Move()
        {
            var rover = new Rover(new Coordinate(5, 3), "E", "M");
            var exception = Assert.Throws<Exception>(() => rover.Move(plateauSize));
            Assert.AreEqual("Invalid movement for rover!", exception.Message);
        }
    }
}