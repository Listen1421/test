using System;

namespace Action委托4
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> messageTarget;

            if (Environment.GetCommandLineArgs().Length > 1)
                messageTarget = s => ShowWindowsMessage(s);
            else
                messageTarget = s => Console.WriteLine(s);

            messageTarget("Hello, World!");
            static void ShowWindowsMessage(string message)
            {
                Console.WriteLine(message);
            }
        }
    }
}
