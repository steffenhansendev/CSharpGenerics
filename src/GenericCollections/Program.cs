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
            // HashSets();
            // Dictionaries();
            SortedDictionaries();
            SortedList();
            SortedSet();
        }

        /// <summary>
        /// A HashSet in which elements will be sorted in (numerical) order 
        /// </summary>
        private static void SortedSet()
        {
            SortedSet<int> sortedSetOfInts = new SortedSet<int>();

            sortedSetOfInts.Add(1);
            sortedSetOfInts.Add(0);
            sortedSetOfInts.Add(-1);

            foreach (int element in sortedSetOfInts)
            {
                Console.WriteLine(element);
            }
        }

        /// <summary>
        /// A List in which KeyValuePairs will be sorted in order of the keys
        /// Adding duplicate keys will throw an exception
        /// Uses less memory than SortedDictionary but has slower insertion and deletion: O(n)
        /// Offers IndexOfKey() and IndexOfValue()
        /// Implemented with two arrays
        /// </summary>
        private static void SortedList()
        {
            SortedList<string, List<Employee>> employeesListsByDepartmentName = new SortedList<string, List<Employee>>();
            
            employeesListsByDepartmentName.Add("Sales", new List<Employee> { new Employee(), new Employee(), new Employee() });
            employeesListsByDepartmentName.Add("Engineering", new List<Employee> { new Employee(), new Employee()});

            foreach (KeyValuePair<string, List<Employee>> employeesListByDepartmentName in employeesListsByDepartmentName)
            {
                Console.WriteLine("The index of the key {0} is {1}", employeesListByDepartmentName.Key,
                    employeesListsByDepartmentName.IndexOfKey(employeesListByDepartmentName.Key));
            }
        }

        /// <summary>
        /// A Dictionary in which KeyValuePairs will be sorted in order of the keys
        /// Adding duplicate keys will throw an exception
        /// Uses more memory than SortedList but offers faster insertion and deletion: O(log (n))
        /// Does not offer IndexOfKey() or IndexOfValue()
        /// Implemented with a binary search tree
        /// </summary>
        private static void SortedDictionaries()
        {
            SortedDictionary<string, List<Employee>> employeesListsByDepartmentName =
                new SortedDictionary<string, List<Employee>>();
            
            employeesListsByDepartmentName.Add("Sales", new List<Employee> { new Employee(), new Employee(), new Employee() });
            employeesListsByDepartmentName.Add("Engineering", new List<Employee> { new Employee(), new Employee() });
            
            foreach (KeyValuePair<string, List<Employee>> employeesListByDepartmentName in employeesListsByDepartmentName)
            {
                Console.WriteLine("The count of employees in {0} is {1}", employeesListByDepartmentName.Key,
                    employeesListByDepartmentName.Value.Count);
            }
        }

        /// <summary>
        /// Key is used to search the Dictionary i.e. for a particular value
        /// Adding duplicate keys will throw an exception
        /// </summary>
        private static void Dictionaries()
        {
            Dictionary<string, Employee> employeesByName = new Dictionary<string, Employee>();
            employeesByName.Add("Scott", new Employee { Name = "Scott" });
            employeesByName.Add("Alex", new Employee { Name = "Alex" });
            employeesByName.Add("Joy", new Employee { Name = "Joy" });
            foreach (KeyValuePair<string, Employee> item in employeesByName)
            {
                Console.WriteLine($"The key {item.Key} maps to the value {item.Value}");
            }

            Dictionary<string, List<Employee>> employeeListsByName = new Dictionary<string, List<Employee>>();
            employeeListsByName.Add("Scott", new List<Employee> { new Employee { Name = "Scott 1" } });
            employeeListsByName["Scott"].Add(new Employee { Name = "Scott 2"});
            foreach (KeyValuePair<string, List<Employee>> item in employeeListsByName)
            {
                Console.WriteLine($"The list of {item.Key} contains:");
                foreach (Employee employee in item.Value)
                {
                    Console.WriteLine($"\t{employee.Name}");
                }
            }

            Dictionary<Department, List<Employee>> employeeListsByDepartment = new Dictionary<Department, List<Employee>>();

            Department department1 = new Department { Id = 1 }; 
            
            employeeListsByDepartment.Add(department1, new List<Employee> { new Employee { Name = "Scott" }, new Employee { Name = "Brian"} });

            Console.WriteLine("Working in Department 1:");
            foreach (Employee employee in employeeListsByDepartment[department1])
            {
                Console.WriteLine($"\t{employee.Name}");
            }
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
