using System;
using System.Collections.Generic;

namespace GenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            // Arrays();
            
            Lists();
        }

        private static void Lists()
        {
            List<Employee> employeesList = new List<Employee>
            {
                new Employee {Name = "Scott"},
                new Employee {Name = "Alex"}
            };

            employeesList.Add(new Employee {Name = "Brian"});
            
            List<int> numbers = new List<int>(10);
            // Capacity is the total number of elements the internal data structure can hold without resizing
            int capacity = -1;
            // When the list is full, it will double its capacity from what it has been initialized with (default = 0)
            while (true)
            {
                if (numbers.Capacity != capacity)
                {
                    capacity = numbers.Capacity;
                    Console.WriteLine(capacity);
                }

                numbers.Add(1);
            }
        }

        private static void Arrays()
        {
            Employee[] employeesArray = new Employee[2]
            {
                new Employee {Name = "Scott"},
                new Employee {Name = "Alex"}
            };

            foreach (Employee employee in employeesArray)
            {
                Console.WriteLine(employee.Name);
            }

            for (int i = 0; i < employeesArray.Length; i++)
            {
                Console.WriteLine(employeesArray[i]);
            }

            Array.Resize(ref employeesArray, 3);

            employeesArray[2] = new Employee {Name = "Brian"};
        }
    }
}
