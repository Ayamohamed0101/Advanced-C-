using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegationwithCalculator
{
//    - Calculator with Operations:
//-Create a Calculator class with a delegate for mathematical operations.
//-Implement methods for addition, subtraction, multiplication, and division.
//-Subscriber methods can perform different operations (e.g., display result, log to a file, store in memory).

    public class Calulator
    {
        public delegate int calulateAction(int x, int y);
        private calulateAction cal;
        public Calulator(calulateAction c)
        {
            cal = c;
        }
        public int operation(int x, int y)
        {
            return cal(x, y);
        }

    }
    internal class Program
    {   public static int logToFile(int x,int y)
        {
            string filename = "log.txt";
            using (StreamWriter writeer=new StreamWriter(filename,true) )
            {
                return x+y; // Code here
            }
        }
        public static int sum(int x, int y)
        {
            return x + y;
        }
        public static int subtract(int x, int y)
        {
            return x - y;
        }
        public static int multiplication(int x, int y)
        {
            return x * y;
        }
        public static int divide(int x, int y)
        {
            return x / y;
        }


        static void Main(string[] args)
        {

            Calulator cal1 = new Calulator(sum);
            Console.WriteLine(cal1.operation(3,5));

            Calulator cal2 = new Calulator(divide);
            Console.WriteLine(cal2.operation(3, 5));
            Calulator cal3 = new Calulator(multiplication);
            Console.WriteLine(cal3.operation(3, 5));
            Calulator logFile = new Calulator(logToFile);
            Console.WriteLine(logToFile(3,6));

        }



    }


}
