namespace Types
{
    using AdditionalExamples;
    using Reference;
    using Value;

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Additional examples: ");

            Additional.RefParamModifier();
            Additional.InParamModifier();
            Additional.OutParamModifier();
            Additional.Boxing();

            Console.WriteLine("End\n");

            Console.WriteLine("Value type examples: ");

            ValueType.PassValueTypeExample();

            Console.WriteLine("End\n");

            Console.WriteLine("Reference type examples: ");

            ReferenceType.PassReferenceTypeExample();

            ReferenceType.PassingReferenceByValue();

            ReferenceType.PassingReferenceByValue2();

            Console.WriteLine("End\n");

            Console.ReadKey(true);
        }
    }
}