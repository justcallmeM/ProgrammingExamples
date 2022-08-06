namespace Types.AdditionalExamples
{
    public class KindsOfParameters
    {

        //boxing occurs when we cast value types to reference types and unboxed when cast back.
        public static void Boxing()
        {

        }

        //output parameters
        /* do not create a new storage location, but use the storage location of the variable specified on the invocation.
           very similar to reference parameters. 
              only differences are: 
                 * The variable specified on the invocation doesn't need to have been assigned a value before it is passed to the function member. 
                      If the function member completes normally, the variable is considered to be assigned afterwards (so you can then "read" it).
                 * The parameter is considered initially unassigned (in other words, you must assign it a value before you can "read" it in the function member).
                 * The parameter must be assigned a value before the function member completes normally.
        */
        public static void OutParamModifier()
        {
            // Declare a variable but don't assign a value to it
            int y;
            
            // Pass it in as an output parameter, even though its value is unassigned
            ChangeValue(out y);
            
            // It's now assigned a value, so we can write it out:
            Console.WriteLine (y);

            static void ChangeValue(out int x)
            {
                // Can't read x here - it's considered unassigned

                // Assignment - this must happen before the method can complete normally
                x = 10;

                // The value of x can now be read:
                int a = x;
            }
        }

        public static void InParamModifier()
        {

        }

        //parameter arrays
        public static void ParamsParamModifier()
        {
            int[] x = {1, 2, 3};

            //In the first invocation, the value of the variable x is passed by value, as the type of x is already an array.
            //In the second invocation, a new array of ints is created containing the two values specified,
            //and a reference to this array is passed (still by value).
            ShowNumbers (x);
            ShowNumbers (4, 5);

            void ShowNumbers (params int[] numbers)
            {
                foreach (int x in numbers)
                {
                    Console.Write (x + " ");
                }
                Console.WriteLine();
            }
        }

        //reference parameters
        public static void RefParamModifier()
        {
            int value = 4;
            int valueRef = 5;
            int[] reference = { 1, 2, 3 };

            Console.WriteLine($"value: {value}, valueRef: {valueRef}, reference: {reference[0]}");

            Test(value, ref valueRef, reference);

            Console.WriteLine($"value: {value}, valueRef: {valueRef}, reference: {reference[0]}");
        }

        private static void Test(int value, ref int valueRef, int[] reference)
        {
            value = 8;
            valueRef = 6;
            reference[0] = 5;
        }
    }
}
