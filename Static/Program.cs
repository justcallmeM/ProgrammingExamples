using Static.Models;

namespace Static
{
    /*
    • When a class is described as static, all members must be static as well.
    • A static member can't be referenced through an instance. Instead, 
        it's referenced through the type name.
    */

    internal class Program
    {
        static void Main(string[] args)
        {
            /* object a = new Guitar(); */// cannot create an instance of a static class

            Guitar.Play();

            Console.WriteLine($"Number of strings: {Guitar.NumOfStrings} ");
            Console.WriteLine($"Random number: {Guitar.RandomNumber}");

            Guitar.NumOfStrings = 10;
            Guitar.RandomNumber = 99;

            Console.WriteLine($"Number of strings: {Guitar.NumOfStrings} ");
            Console.WriteLine($"Random number: {Guitar.RandomNumber}");

            /* OUTPUT

                guitar starts playing
                Number of strings: 0
                Random number: 5
                Number of strings: 10
                Random number: 99

             */
        }
    }
}