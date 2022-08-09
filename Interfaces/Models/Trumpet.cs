namespace Interfaces.Models
{
    using Interfaces;

    public class Trumpet : IWindTypeInstrument
    {
        public int LengthOfPipe { get; set; }
        public string Colour { get; set; }
        public int Weight { get; set; }

        public Trumpet(int lengthOfPipe, string colour, int weight)
        {
            LengthOfPipe = lengthOfPipe;
            Colour = colour;
            Weight = weight;
        }

        public void Blow()
        {
            throw new NotImplementedException();
        }
    }
}
