using System;
using System.Collections.Generic;

namespace _0_Action委托
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> names = new List<String>();
            names.Add("Bruce");
            names.Add("Alfred");
            names.Add("Tim");
            names.Add("Richard");

            // Display the contents of the list using the Print method.
            names.ForEach(Print);

            // The following demonstrates the anonymous method feature of C#
            // to display the contents of the list to the console.
            names.ForEach(delegate (String name)
            {
                Console.WriteLine(name);
            });

            void Print(string s)
            {
                Console.WriteLine(s);
            }
        }
    }
}
