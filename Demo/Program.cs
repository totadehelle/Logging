using System;
using Logging;
using Logging.ConsoleOutput;
using Logging.Enums;
using Logging.FileOutput;

namespace Demo
{
	class Program
	{
		static void Main(string[] args)
		{
			Log.Logger.Configure()
				.SetMinimumLevel(LogLevel.Information)
				.WriteTo.Console()
				.WriteTo.File("log.txt");
			
			Log.Information("Just info");
			Log.Warning("Something expires soon");
			try
			{
				throw new Exception("AAAaaa!");
			}
			catch (Exception e)
			{
				Log.Fatal("Very fatal error", e);
				throw;
			}
		}
	}
}
