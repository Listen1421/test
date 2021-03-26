using System;

namespace Action委托3
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> messageTarget;

            if (Environment.GetCommandLineArgs().Length > 1)
                messageTarget = delegate (string s) { ShowWindowsMessage(s); };
            else
                messageTarget = delegate (string s) { Console.WriteLine(s); };

            messageTarget("Hello, World!");
             static void ShowWindowsMessage(string message)
            {
                Console.WriteLine(message);
            }
        }
    }
}
