namespace CaseStudyMarsRover.ConsoleApp
{
    public static class IntegerExtensions
    {
        public static int Mod(this int number, int modulo)
        {
            var result = number % modulo;
            
            return result < 0 ? result + modulo : result;
        }
    }
}