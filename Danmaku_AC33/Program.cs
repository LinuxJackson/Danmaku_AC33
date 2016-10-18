using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceAnalysis;

namespace Danmaku_AC33
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Service Actived...");
            new MainService().Start();
        }
    }
}
