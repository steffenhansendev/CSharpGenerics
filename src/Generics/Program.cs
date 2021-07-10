﻿using System;
using System.Collections.Generic;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            var buffer = new CircularBufferByArray<double>(capacity: 3);
            ProcessUserInput(buffer);

            IEnumerable<int> elementsAsInts = buffer.AsEnumerable<int>();
            foreach (int element in elementsAsInts)
            {
                Console.WriteLine(element);
            }
            
            ProcessBuffer(buffer);
        }

        private static void ProcessUserInput(IBuffer<double> buffer)
        {
            while (true)
            {
                var value = 0.0;
                var input = Console.ReadLine();

                if (double.TryParse(input, out value))
                {
                    buffer.Write(value);
                    continue;
                }
                break;
            }
        }
        
        private static void ProcessBuffer(IBuffer<double> buffer)
        {
            var sum = 0.0;
            Console.WriteLine("Buffer: ");
            while (!buffer.IsEmpty)
            {
                double value = buffer.Read();
                Console.WriteLine(value);
                sum += value;
            }

            Console.WriteLine("Sum: " + sum);
        }
    }
}
