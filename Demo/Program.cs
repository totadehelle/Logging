using System;
using System.Collections.Generic;
using Logging;
using Logging.ConsoleOutput;
using Logging.Enums;
using Logging.FileOutput;
using Logging.Interfaces;

namespace Demo
{
	class Program
	{
		static void Main(string[] args)
		{
			Log.Logger = new LoggerConfiguration()
				.SetMinimumLevel(LogLevel.Information)
				.SetOutputModules(new List<IOutputModule>()
				{
					new FileModule("log.txt")
				})
				.CreateLogger();
			
			Log.Information("Just info");
			Log.Warning("Something expires soon");
			Log.Debug("Smth");
		}
	}
}
