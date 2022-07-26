namespace ValueAndReferenceTypes
{
    using ValueAndReference.RefKeyword;
    using ValueAndReference.ValueType;

    public class Program
    {
        static void Main(string[] args)
        {
            AdditionalExamples.TestRefValueTypes();
            AdditionalExamples.Boxing();
            ValueType.PassValueTypeExample();

            Console.ReadKey(true);
        }
    }
}