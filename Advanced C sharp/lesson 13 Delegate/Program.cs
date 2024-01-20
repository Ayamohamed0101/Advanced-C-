using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_13_Delegate
{
    internal partial class Program
    {
        public  delegate  void recd(decimal h,decimal w);

        static void Main(string[] args)
        {
            var emp = new Employee[]
            {

                new Employee { Name="aya", Gender="f", Id=1, TotalSales=2090 } ,
                new Employee { Name="mohamed", Gender="m", Id=2, TotalSales=2099 } ,
                new Employee { Name="asmaa", Gender="f", Id=1, TotalSales=8900 } ,
                new Employee { Name="tqwa", Gender="f", Id=1, TotalSales=3355 } ,
                new Employee { Name="amgad", Gender="m", Id=1, TotalSales=4644} ,
                new Employee { Name="ashraf", Gender="m", Id=1, TotalSales=7566} ,
                new Employee { Name="agff", Gender="f", Id=1, TotalSales=5006 } ,
                ///
   
            };


        var Report = new Report();
            Report.EmployeeWith6000PlusSales(emp, isGraterThan2000);
            Report.EmployeeWith6000PlusSales(emp, isGraterThan3000);
            // using method
            Report.EmployeeWith6000PlusSales(emp, isGraterThan6000);
            // without using method
            Report.EmployeeWith6000PlusSales(emp, delegate (Employee e) { return e.TotalSales >= 4644; }) ;
            // lamda expression
            Report.EmployeeWith6000PlusSales(emp,  (Employee e) => e.TotalSales >= 4644   );

            ////
            /// 

         var helper = new REC();
         
            recd recHelper;
            recHelper = helper.getarea;
            recHelper += helper.getarea2;
            recHelper(10, 10);

            Console.WriteLine("After unsubcscibing area");
            recHelper-=helper.getarea2;

            recHelper(10, 10);

        }
        static bool isGraterThan6000(Employee e) => e.TotalSales >= 6000;
        static bool isGraterThan3000(Employee e) => e.TotalSales >= 3000;
        static bool isGraterThan2000(Employee e) => e.TotalSales >= 2000;
        //////////////
        ///

        public class REC
        {
            public void getarea(decimal h,decimal w)
            {
                Console.WriteLine(h*w);
            }
            public void getarea2(decimal h, decimal w)
            {
                Console.WriteLine(2*(h + w));
            }
        }


    }
}

