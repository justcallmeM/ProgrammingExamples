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

    }
}
