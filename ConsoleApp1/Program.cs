using System;
using System.Collections.Generic;
using Logging;
using Logging.ConsoleOutput;
using Logging.Enums;
using Logging.FileOutput;
using Logging.Interfaces;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.GetBuilder().SetMinimumLevel(LogLevel.Verbose)
                .SetDebugOutput(true)
                .WriteToConsole()
                .BuildLogger();

            Log.Verbose("Hello");
        }
    }
}
