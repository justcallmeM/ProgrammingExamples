namespace Abstract.Abstractions
{
    public abstract class Instrument
    {
        public string Colour { get; set; }
        public string Weight { get; set; }

        public abstract void MakeNoise();

        public virtual void Maintain()
        {
            Console.WriteLine("Clean");
        }
    }
}
