namespace AccessModifiers.Modifiers
{
    /*
        • public: The type or member can be accessed by any other code in the same assembly or another assembly that references it. 
          The accessibility level of public members of a type is controlled by the accessibility level of the type itself.
    */

    public class Public
    {
        public int x; // No access restrictions.
        public int y;
    }

    class PublicExample
    {
        static void Method()
        {
            _ = new Public
            {
                // Direct access to public members.
                x = 10,
                y = 15
            };
        }
    }
}
