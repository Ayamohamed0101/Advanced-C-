using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterators_Enumerators_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var ints = new FiveIntegars(1, 2, 3, 4, 5);
            foreach (var i in ints) // error not array that's class
            {
                Console.WriteLine(i); // 
            }
            // so dealling with class as array use :)- Enumrators
        }
    }

    public class FiveIntegars : IEnumerable
    {
        int[] values;
        public FiveIntegars(int n1, int n2, int n3, int n4, int n5)
        {
            values = new[] { n1, n2, n3, n4, n5 };
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in values)
            {
                yield return item;

            }
        }

    }
    //public class FiveIntegars : IEnumerable
    //{
    //    int[] values;
    //    public FiveIntegars(int n1, int n2, int n3, int n4, int n5)
    //    {
    //        values = new[] { n1, n2, n3, n4, n5 };
    //    }

    //    public IEnumerator GetEnumerator() => new Enumerator(this);
    //   class Enumerator : IEnumerator
    //   {
    //        int currentIndex = -1;
    //        FiveIntegars integars;

    //        public Enumerator(FiveIntegars _Integ)
    //        {
    //            integars = _Integ;
    //        }


    //        public object current
    //        {
    //            get 
    //            {
    //                if (currentIndex == -1)
    //                    throw new InvalidOperationException("Enumerator not started yet");
    //                if (currentIndex == integars.values.Length)
    //                    throw new InvalidOperationException("Enumerator ended");
    //                return integars.values[currentIndex]

    //            }
    //        }
    //        public bool moveNext()
    //        {
    //            //throw new NotImplementedException() ;
    //            if (currentIndex >= integars.values.Length - 1)
    //            {
    //                return false;
    //            }
    //            return ++currentIndex < integars.values.Length;
    //        }



    //        public void Reset()
    //        {
    //            currentIndex = -1;
    //        }
    //   } 
    //}


}

