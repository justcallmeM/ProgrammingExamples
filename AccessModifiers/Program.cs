﻿using AccessModifiers_DifferentAssembly;

namespace AccessModifiers
{
    /*
    • public: The type or member can be accessed by any other code in the same assembly or another assembly that references it. 
      The accessibility level of public members of a type is controlled by the accessibility level of the type itself.
    • private: The type or member can be accessed only by code in the same class or struct.
    • protected: The type or member can be accessed only by code in the same class, or in a class that is derived from that class.
    • internal: The type or member can be accessed by any code in the same assembly, but not from another assembly. 
      In other words, internal types or members can be accessed from code that is part of the same compilation.
    • protected internal: The type or member can be accessed by any code in the assembly in which it's declared, 
      or from within a derived class in another assembly.
    • private protected: The type or member can be accessed by types derived from the class that 
      are declared within its containing assembly.
    */

    internal class Program
    {
        public class Guitar
        {
            private int NumOfStrings { get; set; }
            private string Colour { get; set; }
            public int Price { get; set; }
        }

        static void Main(string[] args)
        {
            Guitar guitar = new();

            guitar.Price = 200;
            /// guitar.NumOfStrings = 6; => can't reach this, because it's private
            /// guitar.Colour = "red" => same as for the strings

            Instruments instruments = new();

            Instruments.Trumpet trumpet = new();
            Instruments.Saxophone saxophone = new();
            instruments.NumOfInstruments = 5;
            /// Instruments.Tambourine tambourine = new(); => can't reach since it's protected.
        }
    }
}

namespace AccessModifiers_DifferentAssembly
{
    public class Instruments
    {
        internal int NumOfInstruments { get; set; }

        public int Colour { get; set; }

        public class Trumpet { }

        internal class Saxophone { }

        protected class Tambourine { }
    }
}