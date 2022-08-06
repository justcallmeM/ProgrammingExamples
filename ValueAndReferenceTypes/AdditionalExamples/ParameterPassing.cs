namespace Types.AdditionalExamples
{
    using System.Text;
    using Types.Models;

    public class ParameterPassing
    {
        //object references are passed by value by default.

        /* By default, parameters are value parameters.
         * This means that a new storage location is created for the variable in the function member declaration, 
         * and it starts off with the value that you specify in the function member invocation. 
         * If you change that value, that doesn't alter any variables involved in the invocation
        */

        public static void PassingReferenceTypeByValue1()
        {
            StringBuilder y = new();
            y.Append("hello");
            ChangeValue(y);

            Console.WriteLine(y == null);

            //the value of y isn't changed just because x is set to null. 
            static void ChangeValue(StringBuilder? x) => x = null;
        }

        public static void PassingReferenceTypeByValue2()
        {
            StringBuilder y = new();
            y.Append("hello");
            ChangeValue(y);
            Console.WriteLine(y);

            //after calling ChangeValue, the StringBuilder object that y refers to contains "hello world",
            //as in ChangeValue the data " world" was appended to that object via the reference held in x.
            static void ChangeValue(StringBuilder x) => x.Append(" world");
        }

        public static void PassingReferenceTypeByValue3()
        {
            Person person = new("Mindaugas", 26);

            Console.WriteLine($"At first person is: {person.Name}, {person.Age}");
            ChangeValue(person);
            Console.WriteLine($"After change: {person.Name}, {person.Age}");

            static void ChangeValue(Person person)
            {
                person.Name = "Dominyka";
                person.Age = 30;
            }
        }

        //value of a value type variable is the data itself
        public static void PassingValueTypeByValue1()
        {
            IntHolder y = new();
            y.i = 5;
            ChangeValue(y);
            Console.WriteLine(y.i);

            //when ChangeValue is called, x starts off as a struct with value i = 5. 
            //Its i value is then changed to 10. ChangeValue knows nothing about the variable y, and after the method completes,
            //the value in y will be exactly the same as it was before (i.e. 5).
            static void ChangeValue(IntHolder x) => x.i = 10; //x is a new instance of the object.

            //Understand why if IntHolder was declared as a class instead of a struct, y.i would be 10 after calling ChangeValue.
            //if IntHolder would've been a class, the x would've been a reference to the already created object.
        }

        public static void PassValueTypeByValue2()
        {
            /*
             * When you pass a value-type variable from one method to another, the system creates a separate copy of a variable in another method. 
             * If value got changed in the one method, it wouldn't affect the variable in another method.
            */

            int i = 100;
            ChangeValue(i);
            Console.WriteLine(i);

            static void ChangeValue(int x) => x = 200; //x is a new instance of the object.
        }

        /*
         * When you pass a reference type variable from one method to another, it doesn't create a new copy; instead, it passes the variable's address. 
         * So, If we change the value of a variable in a method, it will also be reflected in the calling method.
        */

        /* Reference parameters don't pass the values of the variables used in the function member invocation - they use the variables themselves. 
         * Rather than creating a new storage location for the variable in the function member declaration, the same storage location is used, 
         * so the value of the variable in the function member and the value of the reference parameter will always be the same. 
         * Reference parameters need the ref modifier as part of both the declaration and the invocation - that means it's always clear 
         * when you're passing something by reference. Let's look at our previous examples, just changing the parameter to be a reference parameter: 
         */

        public static void PassingReferenceTypeByReference()
        {
            StringBuilder y = new();
            y.Append("hello");
            ChangeValue(ref y);

            Console.WriteLine(y == null);

            //the value of y isn't changed just because x is set to null. 
            static void ChangeValue(ref StringBuilder? x) => x = null;
        }

        public static void PassingValueTypeByReference()
        {
            IntHolder y = new();
            y.i = 5;
            ChangeValue(ref y);
            Console.WriteLine(y.i);

            static void ChangeValue(ref IntHolder x) => x.i = 10;
        }
    }
}
