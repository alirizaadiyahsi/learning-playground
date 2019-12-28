namespace CommandPattern.Commands
{
    public abstract class Command
    {
        protected int X;
        protected int Y;

        protected Command(int x, int y)
        {
            X = x;
            Y = y;
        }

        public abstract int Execute();
        public abstract int UndoExecution();
    }
}