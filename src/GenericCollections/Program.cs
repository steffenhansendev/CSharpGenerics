using System;

namespace GenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee[] employees = new Employee[2]
            {
                new Employee {Name = "Scott"},
                new Employee {Name = "Alex"}
            };

            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee.Name);
            }

            for (int i = 0; i < employees.Length; i++)
            {
                Console.WriteLine(employees[i]);
            }

            Array.Resize(ref employees, 3);

            employees[2] = new Employee {Name = "Brian"};
        }
    }
}
