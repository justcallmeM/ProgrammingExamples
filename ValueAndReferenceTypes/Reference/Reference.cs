namespace Types.Reference
{
    //Reference types are stored on the heap.

    //reference type assignments copy the reference
    //reference type is garbage collected
    //reference types assignemnts copy the reference
    //Reference types are nullabel by default

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
        public static void PassReferenceTypeExample()
        {
            /*
             * When you pass a reference type variable from one method to another, it doesn't create a new copy; instead, it passes the variable's address. 
             * So, If we change the value of a variable in a method, it will also be reflected in the calling method.
            */

            string i = "Text is this";

            Console.WriteLine(i);

            ChangeValue(i);

            Console.WriteLine(i);

            static void ChangeValue(string x)
            {
                x = "The text has changed";

                Console.WriteLine(x);
                Console.WriteLine("bullshit. read more john skeet.");
            }
        }
    }
}
