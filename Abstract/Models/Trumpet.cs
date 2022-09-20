namespace Abstract.Models
{
    using Abstractions;

    public class Trumpet : Instrument
    {
        //we must use override keyword before the method
        //is declared as abstract in the child class

        public override void MakeNoise()
        {
            Console.WriteLine("Blow into the horn");
        }
    }
}
