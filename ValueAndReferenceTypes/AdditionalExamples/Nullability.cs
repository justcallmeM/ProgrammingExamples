namespace Types.AdditionalExamples
{
    public class Nullability
    {
        //Value types can not be null unless they are nullable
        //The core of nullable value type support is the Nullable<T> struct. Struct restriction indicates that it can only be initiated with a value type.

        //int num = null;
        //Nullable<int> numNullable = null;
        //int? numNullable2 = null;
    }
}
