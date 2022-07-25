using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static.Models
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
}
