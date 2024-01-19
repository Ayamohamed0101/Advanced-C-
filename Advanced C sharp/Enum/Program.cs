using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CAEnum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in Enum.GetNames(typeof(DAY)) )

            {
                Console.WriteLine($" {item} = {Enum.Parse(typeof(DAY) , item)} ");
            }
            foreach (var item in Enum.GetValues(typeof(DAY)))

            {
                Console.WriteLine($" {item.ToString()} = {(int)item} ");
            }
            ////~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            //var day1 = "friday";// case sensitive must be capital
            //                 //  Console.WriteLine(Enum.Parse(typeof(DAY), day1));

            //if ( Enum.TryParse(day1, out DAY day))
            //{
            //    Console.WriteLine(day);

            //}
            //else
            //{
            //    Console.WriteLine("invalid entry");
            //}
            ////~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            //var day2 = "friday";// case sensitive must be capital

            // if (Enum.IsDefined( typeof(DAY),  day2)) // VALUE 
            // {
            //      Console.WriteLine(Enum.Parse(typeof(DAY), day2));

            //     //Console.WriteLine(day);

            // }
            // else
            // {
            //     Console.WriteLine("invalid entry");
            // }

            ////~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            //var day = DAY.saturday | DAY.sunday;
            //var day2 = DAY.wensday;
            //Console.WriteLine((int)day2);
            //Console.WriteLine(day2);
            //var day3 = DAY.wensday | DAY.tuesday;
            //Console.WriteLine(day3);
            //Console.WriteLine(day);
            ////~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            //if (day.HasFlag(DAY.weekend))
            //{
            //    Console.WriteLine("ENJOY WEEKEND");
            //}
            //if (day2.HasFlag(DAY.weekend))
            //{
            //    Console.WriteLine("ENJOY WEEKEND");
            //}
            ////~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        }
    } 

        
        enum DAY
        {
            NONE     = 0b_0000_0000,//0
            Monday   = 0b_0000_0001,//1
            tuesday  = 0b_0000_0010,//2
            wensday  = 0b_0000_0100,//4
            thrusday = 0b_0000_1000,//8
            friday   = 0b_0001_0000,//16
            saturday = 0b_0010_0000,//32
            sunday   = 0b_0100_0000,//64
            Busday  = Monday | tuesday | wensday |  thrusday | friday,

            weekend = saturday | sunday //0b_0110_0000




        }
    }

