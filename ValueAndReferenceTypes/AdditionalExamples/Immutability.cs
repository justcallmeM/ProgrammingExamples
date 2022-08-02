using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types.AdditionalExamples
{
    public class Immutability
    {
        //once an immutable instance is constructed it can't be changed.
        /*  
         * if you hold a reference to an immutable object, you can feel comfortable in returning it 
         * from a method or passing it to another method, safe in the knowledge that it won't be changed behind your back.
        */

        public static void StringImmutability()
        {
            //Strings are immutable

            //creating reference variable - text
            //creating string object with the value "Starter text"
            string text = "Starter text"; //assign text variable to refer to the "Started text" object in memory.

            Console.WriteLine(text);

            //passing reference by value (by default).
            ChangeValue(text);

            //this line does not change "Starter text" object in memory.
            //Instead, it creates a whole new string object with value "Another text" at a new location in memory,
            //and updates text variable to refer to that new object.
            text = "Another text";

            //The original "Starter text" object in memory still exists,
            //and is completely unchanged, but now there is nothing referring to it,
            //and it can be collected the next time the garbage collector runs.

            Console.WriteLine(text);

            static void ChangeValue(string val)
            {
                //new instance of a string is created alonside new object in memory.
                val = "Text doesn't change";
            }
        }
    }
}
