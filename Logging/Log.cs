using System;
using Logging.Enums;
using Logging.Interfaces;

namespace Logging
{
	public static class Log
	{
		public static ILogger Logger { get; } = LoggerSingleton.Instance;

		public static void Verbose(string message)
		{
			if(Logger.MinimumLevel>LogLevel.Verbose)
				return;
			string logMessage = "[VRB]"
								+ "[" + DateTime.UtcNow + "]"
			                    + "[Message: " + message + "]";
			Logger.Write(logMessage);
		}
		
		public static void Debug(string message)
		{
			
			if (Logger.MinimumLevel > LogLevel.Debug)
				return;
			string logMessage = "[DBG]"
								+ "[" + DateTime.UtcNow + "]"
			                    + "[Message: " + message + "]";
			Logger.Write(logMessage);
		}
		
		public static void Information(string message)
		{
			if (Logger.MinimumLevel > LogLevel.Information)
				return;
			string logMessage = "[INF]"
								+ "[" + DateTime.UtcNow + "]"
			                    + "[Message: " + message + "]";
			Logger.Write(logMessage);
		}
		
		public static void Warning(string message)
		{
			if (Logger.MinimumLevel > LogLevel.Warning)
				return;
			string logMessage = "[WRN]"
								+ "[" + DateTime.UtcNow + "]"
			                    + "[Message: " + message + "]";
			Logger.Write(logMessage);
		}
		
		public static void Error(string message, Exception exception)
		{
			if (Logger.MinimumLevel > LogLevel.Error)
				return;
			string logMessage = "[ERR]"
								+ "[" + DateTime.UtcNow + "]"
			                    + "[Message: " + message + "]"
								+ exception;
			Logger.Write(logMessage);
		}
		
		public static void Fatal(string message, Exception exception)
		{
			string logMessage = "[FAT]"
								+ "[" + DateTime.UtcNow + "]"
			                    + "[Message: " + message + "]"
								+ exception;
			Logger.Write(logMessage);
		}
	}
}