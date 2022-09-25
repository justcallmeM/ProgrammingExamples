namespace Abstract.Example3.Models
{
    // Derive a new class from Employee.
    public class SalesEmployee : Employee
    {
        // New field that will affect the base pay.
        private decimal _salesbonus;

        // The constructor calls the base-class version, and
        // initializes the salesbonus field.
        public SalesEmployee(string name, decimal basepay, decimal salesbonus)
            : base(name, basepay)
        {
            _salesbonus = salesbonus;
        }

        // Override the CalculatePay method
        // to take bonus into account.
        public override decimal CalculatePay()
        {
            return _basepay + _salesbonus;
        }
    }
}

/*
 
    An override method provides a new implementation of the method inherited from a base class. 
    The method that is overridden by an override declaration is known as the overridden base method.

    An overriding property declaration must specify exactly the same access modifier and name as the inherited property.
    [ Beginning with C# 9.0, read-only overriding properties support 
      covariant return types. The overridden property must be virtual, abstract, or override. ]

 */
