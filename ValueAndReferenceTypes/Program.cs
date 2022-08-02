namespace Types
{
    using AdditionalExamples;
    using Reference;
    using Value;
    using static System.Console;

    public class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Additional examples: ");

            KindsOfParameters.RefParamModifier();
            KindsOfParameters.InParamModifier();
            KindsOfParameters.OutParamModifier();
            KindsOfParameters.Boxing();

            WriteLine("End\n");

            WriteLine("Value type examples: ");



            WriteLine("End\n");

            WriteLine("Reference type examples: ");

            ParameterPassing.PassingReferenceTypeByValue3();

            WriteLine("End\n");

            ReadKey(true);
        }
    }
}