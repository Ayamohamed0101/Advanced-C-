using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var name = "aya mohamed";
            char[] chars = name.ToCharArray();
            foreach (char c in chars) 
            {
                int ascci = Convert.ToInt32(c);
                var output = $"  {c} -> ascii  :: {ascci}  ,    {c}       binary  -> {Convert.ToString (ascci,2).PadLeft(8,'0')} ";
                Console.WriteLine(output);
            
            }
        }
    }
}
