namespace Interfaces.Models
{
    using Interfaces;

    public class Guitar : IStringTypeInstrument
    {
        public string Colour { get; set; }
        public int Weight { get; set; }
        public int NumOfStrings { get; set; }

        public Guitar(string colour, int weight, int numOfStrings)
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
}
