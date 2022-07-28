namespace Types
{
    using Types.AdditionalExamples;
    using Types.Reference;
    using Types.Value;

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Additional examples: ");

            Types.AdditionalExamples.AdditionalExamples.RefParamModifier();
            Types.AdditionalExamples.AdditionalExamples.InParamModifier();
            Types.AdditionalExamples.AdditionalExamples.OutParamModifier();
            Types.AdditionalExamples.AdditionalExamples.Boxing();

            Console.WriteLine("End\n");

            Console.WriteLine("Value type examples: ");

            Types.Value.Value.PassValueTypeExample();

            Console.WriteLine("End\n");

            Console.WriteLine("Reference type examples: ");

            Types.Reference.Reference.PassReferenceTypeExample();

            Types.Reference.Reference.PassingReferenceByValue();

            Console.WriteLine("End\n");

            Console.ReadKey(true);
        }
    }
}