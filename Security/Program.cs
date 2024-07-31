using Security.JWT;

namespace Security
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JweExample.Execute();

            JwsEcdsaExample.Execute();

            JwsHmacExample.Execute();

            JwsRsaExample.Execute();

            Console.ReadKey(true);
        }
    }
}
