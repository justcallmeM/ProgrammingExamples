namespace Abstract
{
    using Abstractions;
    using Models;

    /*
        • Class can inherit only ONE regular or abstract class
        • Abstract class can have members that we don't have to implement
        • Abstract class can have members that we DO have to implement.
          Those members will also be described as abstract.
        • Abstract class can have virtual members that have base logic,
          and can be overriden if we want different logic in another class.

        • If we see interface as a contract, then an abstract class is a ghost of
          the class that inherits it.

          ghost - as in an abstract class can not exist on its own and it has similar
                  properties to a class inheriting it. 
    */

    /*  useful info:
        • while writing abstract classes try to use "X is a Y" logic.
        • Base class - is a class that has some base logic that we pass down to derived classes.
	      having a base class with some logic is sometimes bad since we could instantiate it and
	      then access that part of the code. For this reason it is better to abstrac it.
    */



    public class Program
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