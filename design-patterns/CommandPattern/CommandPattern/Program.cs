using System;
using System.Collections.Generic;
using CommandPattern.Commands;

namespace CommandPattern
{
    public class Program
    {
        private static void Main()
        {
            var commands = new List<Command>
            {
                new AddCommand(10, 15),
                new SubtractCommand(25,7),
                new MultiplyCommand(15,7),
                new DivideCommand(15,5)
            };


            foreach (var command in commands)
            {
                Console.WriteLine("Result: {0} \n", command.Execute());
                Console.WriteLine("Result: {0} \n", command.UndoExecution());
            }
        }
    }
}
