namespace Interfaces
{
    /*
    • Class can inherit more than one interface.
    • All members (methods and properties) MUST be implemented 
      in the class that inherits the interface.

    • Interface is a contract and each point of the contract must be addressed. 
    */

    internal class Program
    {
        public interface Instrument
        {
            public string Colour { get; set; }
            public string Weight { get; set; }
        }

        public interface WindType
        {
            public string Pipes { get; set; }

            public void Blow();
        }

        public interface StringType
        {
            public int NumOfStrings { get; set; }

            public void Strum();
            public void Pick();
        }

        public class Guitar : Instrument, StringType
        {
            public string Colour { get; set; }
            public string Weight { get; set; }
            public int NumOfStrings { get; set; }

            public Guitar(string colour, string weight, int numOfStrings)
            {
                Colour = colour;
                Weight = weight;
                NumOfStrings = numOfStrings;
            }

            public void Strum()
            {
                Console.WriteLine("*strumming the guitar strings*");
            }

            public void Pick()
            {
                Console.WriteLine("*picking the guitar strings*");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}