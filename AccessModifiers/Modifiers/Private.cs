using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers.Modifiers
{
    /*
        • private: The type or member can be accessed only by code in the same class or struct.
        • usually private fields have underscore before the name begins.
    */

    class Private
    {
        double _test;   // private access by default

        private readonly string _name = "FirstName, LastName";
        private readonly double _salary = 100.0;

        public string GetName()
        {
            return _name;
        }

        public double Salary
        {
            get { return _salary; }
        }
    }

    class PrivateExample
    {
        static void Method()
        {
            var e = new Private();

            // The data members are inaccessible (private), so
            // they can't be accessed like this:
            //    string n = e._name;
            //    double s = e._salary;

            // '_name' is indirectly accessed via method:
            string n = e.GetName();

            // '_salary' is indirectly accessed via property
            double s = e.Salary;
        }
    }
}
