using System;
using SortApplication.BussinessLogic.Interfaces;

namespace SortApplication.BussinessLogic
{
    internal class ConsoleWrapper : IConsole
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}