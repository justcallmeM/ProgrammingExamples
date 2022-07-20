namespace Abstract.Models
{
    using Abstract.Abstractions;

    public class Trumpet : Instrument
    {
        public override void MakeNoise()
        {
            Console.WriteLine("Blow into the horn");
        }
    }
}
