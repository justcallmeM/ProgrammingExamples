namespace Static
{
    /*
    • When a class is described as static, all members must be static as well.
    • A static member can't be referenced through an instance. Instead, 
        it's referenced through the type name.
    • 
    */

    internal class Program
    {
        public class Guitar
        {
            public string name;

            public Guitar(string name)
            {
                this.name = name;
            }

            /* 
               you can initialize a static field by using another static field that is not yet declared. 
               The results will be undefined until you explicitly assign a value to the static field.
            */
            public static int NumOfStrings = RandomNumber;

            public static int RandomNumber = 5;

            public static void Play()
            {
                string instrument = "Guitar";

                Console.WriteLine(GetReady(instrument));
                Console.WriteLine($"{instrument} starts playing");

                static string GetReady(string instrument)
                {
                    /* A static local function can't capture local variables or instance state. */
                    return $"getting readyt o play {instrument}";
                }
            }
        }

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