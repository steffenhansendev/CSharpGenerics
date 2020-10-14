using System;
using System.Collections.Generic;

namespace GenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            // Arrays();
            // Lists();

            Queues();
        }
        
        /// <summary>
        /// First In, First Out (FIFO)
        /// </summary>
        private static void Queues()
        {
            Queue<Employee> employeesQueue = new Queue<Employee>();
            employeesQueue.Enqueue(new Employee { Name = "Alex" });
            employeesQueue.Enqueue(new Employee { Name = "Dani" });
            employeesQueue.Enqueue(new Employee { Name = "Chris" });

            while (employeesQueue.Count > 0)
            {
                Employee employee = employeesQueue.Dequeue();
                Console.WriteLine(employee.Name);
            }
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
