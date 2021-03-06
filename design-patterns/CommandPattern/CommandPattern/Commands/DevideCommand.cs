﻿using System;

namespace CommandPattern.Commands
{
    public class DivideCommand : Command
    {
        private readonly Calculator _calculator = new Calculator();

        public DivideCommand(int x, int y)
            : base(x, y)
        {

        }

        public override int Execute()
        {
            _calculator.SetAction(Actions.Divide);

            Console.WriteLine("{0} / {1}", X, Y);

            return _calculator.GetResult(X, Y);
        }

        public override int UndoExecution()
        {
            if (_calculator.CurrentResult != X / Y)
            {
                throw new InvalidOperationException("There is no possible undo action!");
            }

            _calculator.SetAction(Actions.Multiply);

            Console.WriteLine("{0} * {1}", _calculator.CurrentResult, Y);

            return _calculator.GetResult(_calculator.CurrentResult, Y);
        }
    }
}