
namespace FixItAppConsoleTest 
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Guid.NewGuid().ToString());
            Console.WriteLine(Guid.NewGuid().ToString());
            Console.ReadKey();
        }
    }
}