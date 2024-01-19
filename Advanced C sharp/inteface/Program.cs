using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace inteface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // var v = new vechial();// can't create intstance of class vechial as it is abstract class
            var v = new Honda("klskl","fsdf" ,5);
            MyInterface v2 = new Honda("", "", 343);
            v2.load();
            v2.unload();
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            IDreivable v3 = new Honda("", "", 3);
            v3.stop();
            v3.move();
        }
    }
    public  abstract class vechial  // abstract ==> preventing created  object
    {
        protected string brand;
        protected string model;
        protected int year;
        public vechial(string brand, string model, int year)
        {
            this.brand = brand;
            this.model = model;
            this.year = year;
        }


    }
    interface IDreivable
    {

        void stop();
        void move();

    }
    interface MyInterface
    {
      
        void load();
        void unload();
        
    }
    public class Honda: vechial , IDreivable,MyInterface //conctrete
         // we must call constructor related to base class
    {
        public Honda(string brand, string model, int year) : base(brand, model, year)
        {
        
        
        
        }
        public void load()
        { Console.WriteLine("loading"); }
        public void unload()
        { Console.WriteLine("unloading"); }
        public void move()
        { Console.WriteLine("moving"); }
        public void stop()
        { Console.WriteLine("stoping"); }

    }
}
