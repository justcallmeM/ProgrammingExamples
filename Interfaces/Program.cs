namespace Interfaces
{
    using Interfaces;
    using Models;

    /*

    • Interface is a contract and each point of the contract must be addressed. 

    • Class can inherit more than one interface.
    • All members (methods and properties) MUST be implemented 
      in the class that inherits the interface.
    • There are no access modifiers on properties. Everything is public.
    • 

    */

    internal class Program
    {
        static void Main(string[] args)
        {
            IStringTypeInstrument guitar = new Guitar("brown", 3, 6);

            List<IInstrument> instruments = new() 
            {
                new Guitar("brown", 3, 6),
                new Trumpet(12, "brass", 4)
            };

            //showcase how inheriting in interface from another interface could be useful.
            //also this shows that we don't have to change this code even if we add another instrument.
            foreach (IInstrument instrument in instruments)
            {
                Console.WriteLine($"instruments weight is: {instrument.Weight}");

                if (instrument is IStringTypeInstrument stringType)
                {
                    Console.WriteLine($"number of strings {stringType.NumOfStrings}");
                }
            }

            Console.WriteLine($"My guitar properties - Colour: {guitar.Colour}; Weight: {guitar.Weight}; Number of strings: {guitar.NumOfStrings};");

            Console.ReadKey(true);
        }
    }
}