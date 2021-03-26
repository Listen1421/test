using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            string ss = "['50000','30000','50001','50002','50003','50004','30001','30002','50005','50006','50007','30003','50008','50009','50010','50011','50012','50013','50014','50015','50016','30004','30005','30006','30007','30008','30009','30010','50017','30011','50018']";
            int i = ss.Length;
            DateTime date = Convert.ToDateTime("2021-03-22 00:00:00");
            var s = TimeCalculation.DateDiffOfDay(date,DateTime.Now);


            decimal dec = 111111111111;
            Console.WriteLine(dec);

            string[] a = new string[2];
            a[0] = "hi";
            object[] b = a;
            Console.WriteLine(b[0]);
            Console.WriteLine(b[1]);
            a[0] = "hi";
            b[1] = 42;



            Console.WriteLine(b[0]);
            Console.WriteLine(b[1]);
        }
    }
}
