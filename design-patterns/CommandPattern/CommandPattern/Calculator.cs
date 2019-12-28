using System;

namespace CommandPattern
{
    public class Calculator
    {
        private Actions _currentAction;
        public int CurrentResult;

        public void SetAction(Actions action)
        {
            _currentAction = action;
        }

        public int GetResult(int x, int y)
        {
            CurrentResult = _currentAction switch
            {
                Actions.Add => (x + y),
                Actions.Subtract => (x - y),
                Actions.Multiply => (x * y),
                Actions.Divide => (x / y),
                _ => throw new InvalidOperationException("This operation is not supported!")
            };

            return CurrentResult;
        }
    }
}