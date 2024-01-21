using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Date d1 = new Date();
            d1.day = 1;
            d1.month = 1;   
            d1.year = 1;
      // Console.WriteLine($" {d1.day.ToString().PadLeft(2, '0')}/ {d1.month.ToString().PadLeft(2, '0')}/{d1.year.ToString().PadLeft(4, '0')} ");
           Console.WriteLine(d1.getDate());
        }
        public class Date
        {
            public int year;
            public int month;
            public int day;
            public string getDate()
            {
           return    ($" {day.ToString().PadLeft(2, '0')}/ {month.ToString().PadLeft(2, '0')}/ {year.ToString().PadLeft(4, '0')} ");

            }
        }
    }
}
