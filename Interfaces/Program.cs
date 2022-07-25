namespace Interfaces
{
    using Interfaces;
    using Models;

    /*
    • Class can inherit more than one interface.
    • All members (methods and properties) MUST be implemented 
      in the class that inherits the interface.

    • Interface is a contract and each point of the contract must be addressed. 
    */

    internal class Program
    {
        static void Main(string[] args)
        {
            IStringType guitar = new Guitar("brown", "3kg", 6);

            Console.WriteLine($"My guitar properties - Colour: {guitar.Colour}; Weight: {guitar.Weight}; Number of strings: {guitar.NumOfStrings};");

            Console.ReadKey(true);
        }
    }
}