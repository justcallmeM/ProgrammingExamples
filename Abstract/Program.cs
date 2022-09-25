namespace Abstract
{
    using Abstract.Example1.Models;
    using Abstract.Example2.Models;
    using Abstract.Example2.Models.Abstractions;
    using Abstract.Example3.Models;

    public class Program
    {
        static void Main(string[] args)
        {
            Example1();

            Example2();

            Example3();

            Console.ReadKey(true);

            static void Example1()
            {
                var sq = new Square(12);

                Console.WriteLine($"Area of the square = {sq.GetArea()}");
                // Output: Area of the square = 144
            }

            static void Example2()
            {
                var o = new DerivedClass();
                o.AbstractMethod();
                Console.WriteLine($"x = {o.X}, y = {o.Y}");
                // Output: x = 111, y = 161

                //BaseClass bc = new BaseClass();   // Error: cannot create an instance of the abstract class 'BaseClass'.
            }

            static void Example3()
            {
                // Create some new employees.
                var employee1 = new SalesEmployee("Alice", 1000, 500);
                var employee2 = new Employee("Bob", 1200);

                Console.WriteLine($"Employee1 {employee1.Name} earned: {employee1.CalculatePay()}");
                Console.WriteLine($"Employee2 {employee2.Name} earned: {employee2.CalculatePay()}");
                /*
                    Output:
                    Employee1 Alice earned: 1500
                    Employee2 Bob earned: 1200
                */
            }
        }
    }
}

/*
    • Class can inherit only ONE regular or abstract class

    • Abstract class can have members that we don't have to implement

    • Abstract class can have members that we DO have to implement.
      Those members will also be described as abstract.

    • Abstract class can have virtual members that have base logic,
      and can be overriden if we want different logic in another class.

    • A non-abstract class derived from an abstract class must 
      include actual implementations of all inherited abstract methods and accessors.

    • If we see interface as a contract, then an abstract class is a ghost of
      the class that inherits it.

      ghost - as in an abstract class can not exist on its own and it has similar
              properties to a class inheriting it. 
*/

/*  useful info:

    • while writing abstract classes try to use "X is a Y" logic.

    • Base class - is a class that has some base logic that we pass down to derived classes.
      having a base class with some logic is sometimes bad since we could instantiate it and
      then access that part of the code. For this reason it is better to abstrac it.
*/