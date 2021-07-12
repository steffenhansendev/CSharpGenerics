using System;

namespace Generics
{
    public class EveryDayDelegates
    {
        private Action<object> _callBack1;
        private Func<double, double, double> _callBack2;
        private Predicate<DateTime> _callBack3;
        
        public void Run()
        {
            _callBack1 = new Action<object>(CallBack1Implementation);
            _callBack2 = new Func<double, double, double>(CallBack2Implementation);
            _callBack3 = new Predicate<DateTime>(IsItFriday);

            _callBack1(_callBack3(new DateTime()));
        }

        private void CallBack1Implementation(object data)
        {
            Console.WriteLine(data);
        }

        private double CallBack2Implementation(double a, double b)
        {
            return a * b;
        }

        private bool IsItFriday(DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Friday;
        }
    }
}