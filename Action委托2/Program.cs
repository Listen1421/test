using System;

namespace Action委托2
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> messageTarget;

            if (Environment.GetCommandLineArgs().Length > 1)
                messageTarget = ShowWindowsMessage;
            else
                messageTarget = Console.WriteLine;

            messageTarget("Hello, World!");
            static void ShowWindowsMessage(string message)
            {
                Console.WriteLine(message);
            }
        }
    }
}
