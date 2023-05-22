namespace Delegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EasyDifficultyDelegateExample.Program.Execute();

            Console.ReadKey(true);
        }
    }
}

/* My own thoughts:
 
    Using delegates requires you think about the names of the properties even more than usually.
 
 */


/*

    Let's say you have a list of integers and you want to perform some operations on each 
    element of the list. One operation is to square the number, and another operation 
    is to double the number. Instead of writing separate methods for each operation 
    and manually deciding which method to call based on a condition, you can use a 
    delegate to dynamically choose the operation to perform.
 
*/
namespace EasyDifficultyDelegateExample
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        // Delegate declaration
        delegate int MathOperation(int x);

        static int Square(int x) => x * x;

        static int Double(int x) => x * 2;

        public static void Execute()
        {
            List<int> numbers = new() { 1, 2, 3, 4, 5 };

            // Delegate instance
            MathOperation operation;

            // Perform square operation
            operation = Square;
            ProcessNumbers(numbers, operation);

            Console.WriteLine();

            // Perform double operation
            operation = Double;
            ProcessNumbers(numbers, operation);
        }

        static void ProcessNumbers(List<int> numbers, MathOperation operation)
        {
            foreach (int number in numbers)
            {
                int result = operation(number);

                Console.WriteLine(result);
            }
        }
    }
}
/*
 
    In this example, we have a delegate named MathOperation that represents a method that 
    takes an integer parameter and returns an integer. We also have two methods, Square and 
    Double, which perform different operations on an integer.
    
    In the Main method, we create a list of integers and then dynamically choose the operation 
    to perform using the delegate operation. First, we assign the Square method to the 
    delegate and call the ProcessNumbers method, which processes each number in the 
    list by squaring it. Then, we assign the Double method to the delegate and call 
    the ProcessNumbers method again, this time processing each number by doubling it.
    
    Using a delegate allows us to write a generic ProcessNumbers method that can work 
    with different operations without having to modify the method itself. We can easily 
    switch between operations by assigning different methods to the delegate, 
    making our code more flexible and reusable.

    As you can see, by using a delegate, we can dynamically choose the operation 
    to perform without duplicating code or adding complex conditional statements.
    Delegates provide a clean and efficient way to decouple the logic of an 
    operation from the code that uses it, improving code organization and maintainability.

*/

/*

    Let's say you have a program that manages a collection of products. 
    Each product has an ID, name, and price. You need to perform various 
    operations on the collection, such as finding products with a specific 
    condition, calculating the total price of the products, and applying a 
    discount to each product. By using delegates, you can decouple the operations 
    from the collection and easily switch between different behaviors.

*/
namespace ModerateDifficultyDelegateExample
{
    using System;
    using System.Collections.Generic;

    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class Program
    {
        delegate bool ProductCondition(Product product);
        delegate decimal PriceCalculator(Product product);
        delegate void ProductModifier(Product product);

        static void Execute()
        {
            List<Product> products = new List<Product>
            {
                new Product { ID = 1, Name = "Product 1", Price = 10.99m },
                new Product { ID = 2, Name = "Product 2", Price = 15.49m },
                new Product { ID = 3, Name = "Product 3", Price = 20.99m },
                new Product { ID = 4, Name = "Product 4", Price = 5.99m }
            };

            Console.WriteLine("Original Product List:");
            PrintProducts(products);

            Console.WriteLine();

            // Find products with price greater than $10
            List<Product> expensiveProducts = FilterProducts(products, p => p.Price > 10);
            Console.WriteLine("Expensive Products (Price > $10):");
            PrintProducts(expensiveProducts);

            Console.WriteLine();

            // Calculate the total price of all products
            decimal totalPrice = CalculateTotalPrice(products, p => p.Price);
            Console.WriteLine($"Total Price of Products: ${totalPrice}");

            Console.WriteLine();

            // Apply a 20% discount to each product
            ModifyProducts(products, p => p.Price *= 0.8m);
            Console.WriteLine("Products after 20% Discount:");
            PrintProducts(products);
        }

        // Method to filter products based on a condition
        static List<Product> FilterProducts(List<Product> products, ProductCondition condition) //Predicate<Product>
        {
            List<Product> filteredProducts = new();
            foreach (Product product in products)
            {
                if (condition(product))
                {
                    filteredProducts.Add(product);
                }
            }
            return filteredProducts;
        }

        // Method to calculate the total price of products using a calculator
        static decimal CalculateTotalPrice(List<Product> products, PriceCalculator calculator) //Func<Product, decimal>
        {
            decimal totalPrice = 0;
            foreach (Product product in products)
            {
                totalPrice += calculator(product);
            }
            return totalPrice;
        }

        // Method to modify products using a product modifier
        static void ModifyProducts(List<Product> products, ProductModifier modifier) //Action<Product>
        {
            foreach (Product product in products)
            {
                modifier(product);
            }
        }

        // Method to print the details of products
        static void PrintProducts(List<Product> products)
        {
            foreach (Product product in products)
            {
                Console.WriteLine($"ID: {product.ID}, Name: {product.Name}, Price: ${product.Price}");
            }
        }
    }
}
/*

    In this example, we define three delegate types: 
    ProductCondition for filtering products based on a condition, 
    PriceCalculator for calculating the price of a product, and ProductModifier 
    for modifying product properties.
    
    We have a list of Product objects, and we perform various operations on it using delegates. 
    First, we filter the products to find the expensive ones

*/

/*

    Let's say you're building a game that involves different types of enemies. 
    Each enemy has a health value and can be attacked. However, different enemies 
    have different attack behaviors. By using delegates, you can define and assign 
    attack behaviors dynamically, making it easier to handle different enemy types 
    with varying attack logic.

*/
namespace HardDifficultyDelegateExample
{
    using System;

    public abstract class Enemy
    {
        public int Health { get; set; }

        // Delegate declaration for attack behavior
        public delegate void AttackBehavior();

        // Delegate instance for attack behavior
        protected AttackBehavior attackBehavior;

        public Enemy(int health)
        {
            Health = health;
        }

        // Method to perform the attack
        public void Attack()
        {
            Console.WriteLine($"Enemy with health {Health} is attacking...");
            attackBehavior?.Invoke();
        }
    }

    // Enemy types with different attack behaviors
    public class MeleeEnemy : Enemy
    {
        public MeleeEnemy(int health) : base(health)
        {
            // Assign the attack behavior using a lambda expression
            attackBehavior = () => Console.WriteLine("Performing melee attack!");
        }
    }

    public class RangedEnemy : Enemy
    {
        public RangedEnemy(int health) : base(health)
        {
            // Assign the attack behavior using a lambda expression
            attackBehavior = () => Console.WriteLine("Performing ranged attack!");
        }
    }

    public class MagicEnemy : Enemy
    {
        public MagicEnemy(int health) : base(health)
        {
            // Assign the attack behavior using a lambda expression
            attackBehavior = () => Console.WriteLine("Performing magic attack!");
        }
    }

    public class Program
    {
        static void Execute()
        {
            MeleeEnemy meleeEnemy = new MeleeEnemy(100);
            RangedEnemy rangedEnemy = new RangedEnemy(150);
            MagicEnemy magicEnemy = new MagicEnemy(200);

            meleeEnemy.Attack();
            rangedEnemy.Attack();
            magicEnemy.Attack();
        }
    }
}
/*
 
    In this example, we have a base Enemy class that defines the common 
    properties and behavior of all enemies. It also declares an AttackBehavior delegate.
    
    Each enemy type (MeleeEnemy, RangedEnemy, and MagicEnemy) inherits from the base 
    Enemy class and sets its attack behavior by assigning a lambda expression 
    to the attackBehavior delegate instance.
    
    In the Main method, we create instances of different enemy types and invoke their 
    Attack method. As each enemy attacks, the assigned attack behavior is dynamically 
    invoked using the delegate. This allows each enemy type to have 
    its own unique attack logic.
    
    By using delegates, we decouple the attack behavior from the base Enemy 
    class and make it easy to customize the behavior for each enemy type. 
    This approach provides flexibility and extensibility, allowing you to add 
    new enemy types with different attack behaviors without modifying the 
    base class or existing code.
 
*/




/*
    Action Delegate: The Action delegate is a predefined delegate type in C# that represents 
    a method that doesn't return a value (void) but can take up to 16 input parameters. 
    It is typically used for performing an action or operation without returning a result. 
    For example, you can use an Action delegate to encapsulate a method that performs a 
    specific task or modifies some state.

    Func Delegate: The Func delegate is another predefined delegate type in C# that represents 
    a method that takes one or more input parameters and returns a value. Func delegates can 
    have up to 16 input parameters, with the last parameter representing the return type. 
    The Func delegate is commonly used when you need to encapsulate a method that performs 
    a computation and returns a result.

    // Example using Action delegate
        Action<string> printMessage = message => Console.WriteLine(message);
        printMessage("Hello, world!"); // Output: Hello, world!
    
    // Example using Func delegate
        Func<int, int, int> addNumbers = (x, y) => x + y;
        int sum = addNumbers(3, 5); // sum = 8

 
 */



/*
    C# delegates are a powerful feature that allows you to treat functions as first-class objects, 
    enabling you to pass them as arguments to other methods, store them in variables, and invoke them dynamically. 
    Delegates are essentially function pointers or references to methods, providing a way to encapsulate 
    and invoke methods with similar signatures.
    
    
    1. Delegate Declaration: To declare a delegate, you define its signature, 
    which specifies the return type and parameters of the methods it can reference. 
    Here's an example delegate declaration:
    
        delegate void MyDelegate(int x, int y);
    
    The above delegate can reference methods that take two int parameters and return void.
    
    
    2. Delegate Instantiation: To create an instance of a delegate, you need to associate it with a 
    method that has a compatible signature. You can do this using a method name, 
    lambda expression, or an anonymous method. 
    Here are examples of delegate instantiation:
    
    Using a method name:
    
        void Add(int a, int b)
        {
            Console.WriteLine(a + b);
        }
        
        MyDelegate del = Add;
    
    Using a lambda expression:
    
        MyDelegate del = (a, b) => Console.WriteLine(a + b);
    
    Using an anonymous method:
    
        MyDelegate del = delegate(int a, int b) { Console.WriteLine(a + b); };
    
    
    3. Delegate Invocation: Once you have an instance of a delegate, you can invoke it as if it were a regular method. 
    Invoking a delegate will call all the methods it references in the order they were added.
    Here's how you can invoke a delegate:
    
        del(5, 3); // Invokes the delegate, which calls the referenced method(s)
    
    
    4. Multicast Delegates: C# delegates can be multicast, meaning they can reference multiple methods. 
    When a multicast delegate is invoked, all the referenced methods are called. 
    You can use the += and -= operators to add or remove methods from a multicast delegate. 
    Here's an example:
    
        delegate void MyMulticastDelegate();
        
        void Method1() { Console.WriteLine("Method 1"); }
        void Method2() { Console.WriteLine("Method 2"); }
        
        MyMulticastDelegate multicastDelegate = Method1;
        multicastDelegate += Method2;
        
        multicastDelegate(); // Invokes both Method1 and Method2
    
    
    5. Delegate Chains: Multicast delegates allow you to create chains of methods. 
    When a delegate chain is invoked, the methods are called sequentially in the order they were added. 
    Each method in the chain can choose to return a value or modify the parameters. 
    However, only the return value of the last method in the chain is propagated back to the caller. 
    Here's an example:
    
        delegate int MyDelegateChain(int x);
        
        int AddTwo(int x) { return x + 2; }
        int MultiplyByThree(int x) { return x * 3; }
        
        MyDelegateChain chain = AddTwo;
        chain += MultiplyByThree;
        
        int result = chain(5); // Invokes both methods in the chain: MultiplyByThree(AddTwo(5))
        // The result will be 21 (5 + 2) * 3
    
    
    6. Built-in Delegates: C# provides several built-in delegate types in the System namespace 
    that you can use without explicitly declaring your own delegate types. Some of the commonly 
    used built-in delegates are Action, Func, Predicate, etc. 
    These delegate types are generic and can work with different signatures. 
    Here are a few examples:
    
        // Action delegate: Takes zero or more input parameters and does not return a value
        Action<int, int> actionDelegate = (x, y) => Console.WriteLine(x + y);
        
        // Func delegate: Takes zero or more input parameters and returns a value
        Func<int, int, int> funcDelegate = (x, y) => x + y;
        
        // Predicate delegate: Takes an input parameter and returns a boolean value
        Predicate<int> predicateDelegate = x => x > 0;
    
    These are the key concepts you need to know about C# delegates. 
    Delegates are extensively used in event handling, asynchronous programming, 
    and LINQ (Language-Integrated Query) in C#. They provide a flexible way to decouple 
    and modularize code by allowing you to pass methods as arguments 
    and dynamically choose which method to invoke at runtime.

*/


/*
 
    Use a Custom Delegate Type:

    Meaningful Naming: If the delegate represents a specific behavior or concept in 
    your domain, it can be beneficial to define a custom delegate type with 
    a meaningful name. This improves code readability and expresses the intent more clearly.

    Encapsulation of Behavior: If the delegate represents a specific behavior that 
    you want to encapsulate and reuse in multiple places, a custom delegate type 
    can provide a clear abstraction for that behavior.

    Specific Signature: If you need a delegate with a specific signature that is 
    not covered by the predefined delegate types, defining a custom delegate type 
    allows you to specify the exact parameter types and return type that 
    match your requirements.
    
    Enhancing Code Readability: In some cases, using a custom delegate type can improve 
    the readability of your code by conveying the intent and purpose of the 
    delegate more explicitly. This is especially true when the delegate type is 
    used extensively throughout your codebase.
    

    Use Action or Func:
    
    Simplicity and Familiarity: If the delegate you need to define has a simple void 
    return type or requires a function with up to 16 parameters, using Action or Func
    can be more straightforward and familiar to other developers. It avoids the need 
    to define a separate custom delegate type for simple scenarios.
    
    Common Use Cases: Action and Func are widely recognized delegate types in the .NET 
    framework and are commonly used for general-purpose scenarios, such as event handling, 
    asynchronous operations, and LINQ queries. Utilizing these predefined delegate types 
    can make your code more familiar to other developers and align with established conventions.
    
    Code Reuse: Action and Func are generic delegate types that can handle a 
    wide range of scenarios. By leveraging these predefined delegate types, you 
    can benefit from code reuse and compatibility with existing APIs and libraries 
    that accept Action or Func delegates.
    
    In summary, custom delegate types are useful when you want to define a specific 
    behavior, encapsulate functionality, or provide a more meaningful abstraction 
    in your code. On the other hand, Action and Func are convenient for common scenarios, 
    providing simplicity, familiarity, and compatibility with existing code and libraries. 
    Consider your specific requirements, readability goals, and the conventions of 
    your codebase when choosing between custom delegate types and the predefined delegate types.

 */