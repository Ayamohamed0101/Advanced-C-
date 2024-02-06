using System;

namespace lesson_13_Delegate
{
    public class Report
    {

        public delegate bool illegableSales(Employee e);
        public void EmployeeWith6000PlusSales(Employee[] employees, illegableSales ISillegableSales) 
        {

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
            foreach (var e in employees)
            {
                if (ISillegableSales(e)) 
                {
                    Console.WriteLine($"{e.Name}| {e.Gender} | {e.Id}");
                }
            }
        }
        
    }
}
