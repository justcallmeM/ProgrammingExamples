namespace Types.Value
{
    //value type assignments copy the entire value.
    /* value types are allocated either on the stack or inline in containing types 
     * and deallocated when the stack unwinds or when their containing type gets deallocated.
    */

    //Value types:
    /* non nullable value type:
     *     enum
     *     struct type: 
     *         struct,
     *         simple type: 
     *             bool
     *             numeric type: 
     *                 integral type: 
     *                     sbyte, byte, short, ushort, int, uint, long, ulong, char;
     *                 floating point type: 
     *                     float, double
     *                 decimal
     * nullable value type:
     *     non nullable value type with '?'
     */

    //Value types are stored in the stack.
    public class ValueType
    {
        public static void PassValueTypeExample()
        {
            /*
             * When you pass a value-type variable from one method to another, the system creates a separate copy of a variable in another method. 
             * If value got changed in the one method, it wouldn't affect the variable in another method.
            */

            int i = 100;

            Console.WriteLine(i);

            ChangeValue(i);

            Console.WriteLine(i);

            static void ChangeValue(int x)
            {
                x = 200;

                Console.WriteLine(x);
            }
        }

        //Value types can not be null unless they are nullable
        //The core of nullable value type support is the Nullable<T> struct. Struct restriction indicates that it can only be initiated with a value type.

        //int num = null;
        //Nullable<int> numNullable = null;
        //int? numNullable2 = null;
    }
}
