using System.Text;

namespace Types.Reference
{
    //Reference types are stored on the heap.

    //reference type assignments copy the reference
    //reference type is garbage collected
    //reference types are nullable by default

    //Reference types:
    /*  class type:
     *      class, object, string
     *  interface
     *  delegate
     *  record
     *  dynamic
     *  array type:
     *      value type
     *      class type
     *      interface
     *      delegate
     *      dynamic
     *      pointer (only available in unsafe code)
     */

    public class Reference
    {
        public static void ReferenceExample()
        {
            StringBuilder first = new();

            first.Append("hello");

            StringBuilder second = first;

            first.Append(" world");

            Console.WriteLine(second); // Prints hello world
        }

        public static void PassReferenceTypeExample()
        {
            /*
             * When you pass a reference type variable from one method to another, it doesn't create a new copy; instead, it passes the variable's address. 
             * So, If we change the value of a variable in a method, it will also be reflected in the calling method.
            */

            int[]? numArray = new int[2] { 11, 15 };
            var a = new { FirstName = "Mindaugas" };

            Console.WriteLine(a.FirstName);

            ChangeValueObj(a);

            Console.WriteLine(a.FirstName);

            //PrintArrayValues(numArray);

            //ChangeValue(numArray);

            //PrintArrayValues(numArray);

            static void ChangeValue(int[]? numArray)
            {
                numArray = new int[3] { 1, 2, 3 };
            }

            static void ChangeValueObj(dynamic a)
            {
                a.FirstName = "Vytautas";
            }

            static void PrintArrayValues(int[] numArray)
            {
                StringBuilder builder = new();

                foreach (int num in numArray)
                {
                    builder.Append(num);
                }

                Console.WriteLine(builder.ToString());
            }
        }

        public static void PassingReferenceByValue()
        {
            //Strings are immutable - means that they can only be initialized and set once.

            //creating reference variable - text
            //creating string object with the value "Starter text"
            string text = "Starter text"; //assign text variable to refer to the "Started text" object in memory.

            Console.WriteLine(text);

            //passing reference by value.
            ChangeValue(text);

            //this line does not change "Starter text" object in memory.
            //Instead, it creates a whole new string object with value "Another text" at a new location in memory,
            //and updates text variable to refer to that new object.
            text = "Another text";

            //The original "Starter text" object in memory still exists,
            //and is completely unchanged, but now there is nothing referring to it,
            //and it can be collected the next time the garbage collector runs.

            Console.WriteLine(text);

            static void ChangeValue(string x)
            {
                //new instance of a string is created alonside new object in memory.
                x = "Text doesn't change";

                Console.WriteLine(x);
            }
        }
    }
}
