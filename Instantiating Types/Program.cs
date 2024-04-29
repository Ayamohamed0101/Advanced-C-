using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Instantiating_Types
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // Console.WriteLine(new goon1());
            //Console.WriteLine(new goon2());
            //Console.WriteLine(new goon3());
            Console.Write("Enemy : ");
            var assmblyName = typeof(Program).Assembly.GetName().Name;
           
            do
            {
                var input = assmblyName + Console.ReadLine();
                object obj = null;

                try
                {
                   
                    var enemy = Activator.CreateInstance(assmblyName, input);
                    obj=enemy.Unwrap();
                }
                catch  {   }
                switch (obj)
                {
                    case goon1 g1:
                        Console.WriteLine(g1);
                        break;
                    case goon2 g2:
                        Console.WriteLine(g2);
                        break;
                    case goon3 g3:
                        Console.WriteLine(g3);
                        break;


                    default:
                        Console.WriteLine("Unknown Enemy ");
                        break;
                }
            } while (true);
            //int i =(int) Activator.CreateInstance (typeof(int));
            //i = 3;
            //DateTime dateTime=(DateTime) Activator.CreateInstance (typeof(DateTime),2343,4,2);
            //Console.WriteLine(dateTime);//4/2/2343 12:00:00 AM
            //Console.WriteLine(i);

        }

        public class goon1
        {
            public override string ToString()
            {
                return $"{{ speed {302}  , hitpower {8} , strength= {8093} }}";
            }
        }
        public class goon3
        {
            public override string ToString()
            {
                return $"{{ speed {340}  , hitpower {488} , strength= {3} }}";
            }
        }
        public class goon2
        {
            public override string ToString()
            {
                return $"{{ speed {0}  , hitpower {4} , strength= {83} }}";
            }
        }
    }
}
