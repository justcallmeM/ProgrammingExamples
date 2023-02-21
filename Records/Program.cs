namespace Records
{
        // cia reiktu pasidaryti record scenariju
        // ir paaiskinti kodel pvz nera naudojamos klases ar struct'ai.
        // kodel kazkur naudojam record, o kazkur record struct

        //Records provide concise syntax for types where the fundamental use is storing data. For object-oriented classes, the fundamental use is defining responsibilities.

        // record - a reference type that provides built-in functionality for encapsulating data
        // record class - same as record
        // record struct - value type with similar functionality

        // record positional syntax

        //public record Person(string FirstName, string LastName);
         //Person person = new("Nancy", "Davolio");
         //Console.WriteLine(person);
         //output: Person { FirstName = Nancy, LastName = Davolio }
        

        /* When you use the positional syntax for property definition, the compiler creates:
         * 
         • A public auto-implemented property for each positional parameter provided in the record declaration.
         For record types and readonly record struct types : An init-only property.
         For record struct types : A read-write property.
         • A primary constructor whose parameters match the positional parameters on the record declaration.
         • For record struct types, a parameterless constructor that sets each field to its default value.
         • A Deconstruct method with an out parameter for each positional parameter provided in the record declaration.
              The method deconstructs properties defined by using positional syntax; it ignores properties
              that are defined by using standard property syntax. 
        */

        /* A record type doesn't have to declare any positional properties. You can declare a record without any
           positional properties, and you can declare other fields and properties, as in the following example:
         */
         record Car(string Colour, string Type)
         {
             public decimal Price { get; init; } //without public, the field is implicitly private.
         };

        class Student
        {
            public string FirstName { get; init; }
            public string LastName { get; init; }
        }

        //var s = new Student()
        //{
        //    FirstName = "Jared",
        //    LastName = "Parosns",
        //};
        //s.LastName = "Parsons"; // Error: LastName is not settable

        //init accessor makes immutable objects more flexible by allowing the caller to mutate the members during the act of construction.
        //That means the object's immutable properties can participate in object initializers
        //and thus removes the need for all constructor boilerplate in the type.


        //If the member is accessible and the object is known to be in the construction phase then the member is settable.

        class Base
        {
            public bool Value { get; init; }
        }
        
        class Derived : Base
        {
            public Derived()
            {
                // Not allowed with get only properties but allowed with init
                Value = true;
            }
        }
        
        class Consumption
        {
            void Example()
            {
                var d = new Derived() { Value = true };
            }
        }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}