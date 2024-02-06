using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int a = 20;
            //int b = 10;


            ////demo d1 = new demo();    
            ////d1.dosomthing( a);
            ////Console.WriteLine(a);// passing by value
            //demo d2 = new demo();

            // d2.dosomthing(ref b);
            //Console.WriteLine( b);// passing by refrence

            var numstring = "92758927";
            int number;
            if(!int.TryParse(numstring,out number))
            {
                Console.WriteLine("invalid number");
            }
            else
            {
                Console.WriteLine( $"valid num {numstring }");
            }

        }
    }
    public class demo
    {

        public void dosomthing( ref int  age)
        {
            age += 3;
        
        }


    }
}
