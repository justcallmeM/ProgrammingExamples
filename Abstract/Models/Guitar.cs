namespace Abstract.Models
{
    using Abstractions;

    public class Guitar : Instrument
    {
        public Guitar(string colour, string weight)
        {
            base.Colour = colour;
            base.Weight = weight;
        }

        public override void MakeNoise()
        {
            Console.WriteLine("Strum or pick the guitar strings");
        }

        public override void Maintain()
        {
            Console.WriteLine("Clean and change strings");
        }
    }
}
