namespace Delegates
{
    public class Calculator
    {
        public delegate double Operation(double x, double y);

        public static double Initiate()
        {
            Console.WriteLine("Enter first number and press enter");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number and press enter");
            int y = int.Parse(Console.ReadLine());

            Console.WriteLine(
                @"On the keypad press one of the symbols for:
                    multiplication: *
                    division: /
                    addition: +
                    subtraction: -");

            return Console.ReadKey().Key switch
            {
                ConsoleKey.Multiply => Calculate(x, y, (x, y) => x * y),
                ConsoleKey.Divide   => Calculate(x, y, (x, y) => x / y),
                ConsoleKey.Add      => Calculate(x, y, (x, y) => x + y),
                ConsoleKey.Subtract => Calculate(x, y, (x, y) => x - y),
                _ => throw new ArgumentException(),
            };
        }

        public static double Calculate(double x, double y, Operation operation)
        {
            //validate x
            //validate y

            //log something

            return operation(x, y);
        }
    }
}
