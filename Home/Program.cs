using System;
using HomeLibrary;

namespace Home
{
    class Program
    {
        static void Main(string[] args)
        {
            HomeManager manager = new HomeManager();
            manager.Process();
            Console.ReadLine();
        }
    }
}
