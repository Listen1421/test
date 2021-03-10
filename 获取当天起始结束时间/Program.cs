using System;

namespace 获取当天起始结束时间
{
    class Program
    {
        static void Main(string[] args)
        {
            //当天0时0分0秒：
            DateTime start = Convert.ToDateTime(DateTime.Now.ToString("D").ToString());
            //当天23时59分59秒：
            DateTime end = Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("D").ToString()).AddSeconds(-1);
            Console.WriteLine(start);
            Console.WriteLine(end);
            DateTime date = DateTime.Now;
            Console.WriteLine(date);
            var endtime = (int)date.Subtract(Convert.ToDateTime(end)).TotalSeconds;
            Console.WriteLine(endtime);
        }
    }
}
