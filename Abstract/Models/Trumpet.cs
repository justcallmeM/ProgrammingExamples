namespace Abstract.Models
{
    using Abstractions;

    public class Trumpet : Instrument
    {
        public override void MakeNoise()
        {
            Console.WriteLine("Blow into the horn");
        }
    }
}
