namespace Static
{
    /*
    • When a class is described as static, all members must be static as well.
    • While an instance of a class contains a separate copy of all 
      instance fields of the class, there's only one copy of each static field.
    */

    internal class Program
    {
        public static class Guitar
        {
            public static int NumOfStrings = RandomNumber;

            public static int RandomNumber = 5;

            public static void Play()
            {
                Console.WriteLine("guitar starts playing");
            }
        }

        static void Main(string[] args)
        {
            Guitar.Play();

            Guitar.RandomNumber = 99;

            /* OUTPUT

                NumOfStrings = 0;
                RandomNumber = 5;
                RandomNumber = 99;

             */
        }
    }
}