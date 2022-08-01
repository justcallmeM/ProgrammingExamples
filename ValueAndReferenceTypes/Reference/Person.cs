using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types.Reference
{
    public class Person
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
        }
    }
}
