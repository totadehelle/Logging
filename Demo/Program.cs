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
				.WriteTo.Console();
			
			Log.Information("Just info");
		}
	}
}
