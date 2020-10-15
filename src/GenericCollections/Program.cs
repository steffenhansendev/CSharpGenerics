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
            // Queues();
            // Stacks();
            HashSets();
        }

        /// <summary>
        /// Set in the mathematical sense of word; stores unique elements => no duplicates
        /// Order is not guaranteed
        /// </summary>
        private static void HashSets()
        {
            HashSet<int> intSet = new HashSet<int>();
            intSet.Add(1);
            intSet.Add(2);
            intSet.Add(2);    // Does nothing because the element already exists in the set; returns false
            intSet.Add(3);

            foreach (int integer in intSet)
            {
                Console.WriteLine(integer);
            }

            HashSet<Employee> employeesSet = new HashSet<Employee>();
            employeesSet.Add(new Employee() { Name = "Scott"} );    
            employeesSet.Add(new Employee() { Name = "Scott"} );    // This is not a duplicate even though the have an identical Name property

            Employee duplicateEmployee = new Employee() {Name = "Brian"};

            employeesSet.Add(duplicateEmployee);
            employeesSet.Add(duplicateEmployee);    // This is a duplicate 

            foreach (Employee employee in employeesSet)
            {
                Console.WriteLine(employee.Name);
            }
        }

        /// <summary>
        /// Last In, First Out (LIFO)
        /// </summary>
        private static void Stacks()
        {
            Stack<Employee> employeesStack = new Stack<Employee>();
            employeesStack.Push(new Employee { Name = "First in" });
            employeesStack.Push(new Employee { Name = "Second in" });
            employeesStack.Push(new Employee { Name = "Third in" });

            while (employeesStack.Count > 0)
            {
                Employee employee = employeesStack.Pop();
                Console.WriteLine(employee.Name);
            }
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
