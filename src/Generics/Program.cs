﻿using System;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            var buffer = new CircularBuffer<double>(capacity: 3);
            ProcessUserInput(buffer);
            ProcessBuffer(buffer);
        }

        private static void ProcessBuffer(CircularBuffer<double> buffer)
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

        private static void ProcessUserInput(CircularBuffer<double> buffer)
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
    }
}
