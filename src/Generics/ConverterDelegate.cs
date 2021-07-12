using System;

namespace Generics
{
    public class ConverterDelegate
    {
        public void Run()
        {
            IBuffer<double> buffer = new CircularBuffer<double>(3);
            buffer.Write(1.1);
            buffer.Write(2.2);
            buffer.Write(3.3);
            PrintAsDates(buffer);
        }
        
        private Converter<double, DateTime> _converter;

        private DateTime MyConverter(double numberOfDays)
        {
            return new DateTime(2020, 1, 1).AddDays(numberOfDays);
        }

        private void PrintAsDates(IBuffer<double> numbersOfDays)
        {
            _converter = new Converter<double, DateTime>(MyConverter);
            
            foreach (double numberOfDays in numbersOfDays)
            {
                Console.WriteLine(_converter(numberOfDays));
            }
            
        }
    }
}