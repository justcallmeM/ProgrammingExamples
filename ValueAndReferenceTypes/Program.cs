namespace ValueAndReferenceTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestRefValueTypes();

            Console.ReadKey(true);
        }

        public static void TestRefValueTypes()
        {
            int value = 4;
            int valueRef = 5;
            int[] reference = { 1, 2, 3 };

            Console.WriteLine($"value: {value}, valueRef: {valueRef}, reference: {reference[0]}");

            Test(value, ref valueRef, reference);

            Console.WriteLine($"value: {value}, valueRef: {valueRef}, reference: {reference[0]}");
        }

        public static void Test(int value, ref int valueRef, int[] reference)
        {
            value = 8;
            valueRef = 6;
            reference[0] = 5;
        }
    }
}