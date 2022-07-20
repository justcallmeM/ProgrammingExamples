namespace Abstract
{
    using Abstract.Abstractions;
    using Abstract.Models;

    /*
        • Class can inherit only ONE regular or abstract class
        • Abstract class can have members that we don't have to implement
        • Abstract class can have members that we do have to implement.
          Those members will also be described as abstract.
        • Abstract class can have virtual members that have base logic,
          and can be overriden if we want different logic in another class.

        • If we see interface as a contract, then an abstract class is a ghost of
          the class that inherits it.

          ghost - as in an abstract class can not exist on its own and it has similar
                  properties to a class inheriting it. 
    */


    internal class Program
    {
        static void Main(string[] args)
        {
            /// • Abstract classes can't be instantiated directly. 
            ///   Instrument instrument = new Instrument();

            Instrument guitar = new Guitar("red", "4kg");
            Instrument trumpet = new Trumpet();

            guitar.Maintain();   /// output => Clean and change strings
            trumpet.Maintain();  /// output => Clean
            guitar.MakeNoise();  /// output => Strum or pick the guitar strings
            trumpet.MakeNoise(); /// output => Blow into the horn

            Console.ReadKey(true);
        }
    }
}