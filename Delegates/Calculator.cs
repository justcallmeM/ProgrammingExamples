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

/*
 
Event aggregator: Create an event aggregator that can be used to subscribe to and publish events. Use delegates to define the events and to handle event subscriptions.

Stock ticker: Create a stock ticker that displays real-time stock quotes. Use delegates to define the methods that will be called when new stock quotes are received.

Calculator: Create a calculator that performs basic arithmetic operations. Use delegates to define the methods that will be called when the user selects an operation.

Weather application: Create a weather application that displays current weather conditions and forecasts for a given location. Use delegates to define the methods that will be called to retrieve weather data from various sources.

Chat application: Create a simple chat application that allows users to send messages to each other. Use delegates to define the methods that will be called to handle incoming and outgoing messages.

File watcher: Create a file watcher that monitors a folder for changes and alerts the user when a new file is added or an existing file is modified. Use delegates to define the methods that will be called when a file change is detected.

Image editor: Create an image editor that allows users to apply filters and effects to images. Use delegates to define the methods that will be called to apply the filters and effects.
 

If you have some experience with delegates and are looking for a more challenging project, I would recommend trying the event aggregator or the image editor. These ideas require more advanced knowledge of delegates and how they can be used to manage complex software architectures.

Ultimately, the best idea to start with will depend on your goals and interests. Consider what type of application you would like to build and what features you would like to include, and choose an idea that aligns with those goals. Good luck with your project!

 
 */
