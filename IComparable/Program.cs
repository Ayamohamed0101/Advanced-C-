using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace IComparable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var temps=new List<Temprature>();
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                temps.Add(new Temprature( rnd.Next(-30,50)) ) ;

            }
            temps.Sort(); //Error before using Icomarable
            foreach (var item in temps)
            {
                Console.WriteLine(item.VAL);
                
            }

        }

         class Temprature : IComparable
         {
            private int _value;
            public Temprature(int value)
            {
                _value = value;
            }

            public int VAL => _value;



            public int CompareTO(object obj)
            {
                var temp = obj as Temprature;
                if (obj is null)
                {
                    return -1;
        
                    if (temp == null)
                    {
                        throw new ArgumentException("object is not a  Temperture");
                    }
                }

                return this._value.CompareTo(temp._value);
            }
         }
  
    
    
    }
}
