using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class clsA
    {
        public int x1;
        public static int x2;

        public int Method1() { return x1 + x2; }

        public static int Method2()
        {
            //return clsA.x1+x2;
            return x2;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            clsA objA1 = new clsA();
            clsA objA2 = new clsA();
            objA1.x1 = 7;
            objA2.x1 = 10;

            clsA.x2 = 100;

            Console.WriteLine("objA1.x1={0}", objA1.x1);
            Console.WriteLine("objA2.x1={0}", objA2.x1);
            Console.WriteLine("objA1.method1 result={0}", objA1.Method1());
            Console.WriteLine("objA2.method1 result={0}", objA2.Method1());

            Console.WriteLine("static method2 result={0}", clsA.Method2());//100

            Console.WriteLine("static x2={0}", clsA.x2);



            Console.ReadLine();



        }
    }
}
