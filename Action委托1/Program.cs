using System;

namespace Action委托1
{
    class Program
    {
        delegate void DisplayMessage(string message);
        static void Main(string[] args)
        {
            DisplayMessage messageTarget;

            if (Environment.GetCommandLineArgs().Length > 1)
                messageTarget = ShowWindowsMessage;
            else
                messageTarget = Console.WriteLine;

            messageTarget("Hello, World!");
        }
        private static void ShowWindowsMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
