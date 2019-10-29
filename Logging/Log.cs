using System;
using Logging.Enums;
using Logging.Interfaces;

namespace Logging
{
	public static class Log
	{
		public static ILogger Logger { get; set; }

		public static void Verbose(string message)
		{
			string logMessage = "[VRB]"
								+ "[" + DateTime.UtcNow + "]"
			                    + "[Message: " + message + "]";
			Logger.Write(logMessage, LogLevel.Verbose);
		}
		
		public static void Debug(string message)
		{
			string logMessage = "[DBG]"
								+ "[" + DateTime.UtcNow + "]"
			                    + "[Message: " + message + "]";
			Logger.Write(logMessage, LogLevel.Debug);
		}
		
		public static void Information(string message)
		{
			string logMessage = "[INF]"
								+ "[" + DateTime.UtcNow + "]"
			                    + "[Message: " + message + "]";
			Logger.Write(logMessage, LogLevel.Information);
		}
		
		public static void Warning(string message)
		{
			string logMessage = "[WRN]"
								+ "[" + DateTime.UtcNow + "]"
			                    + "[Message: " + message + "]";
			Logger.Write(logMessage, LogLevel.Warning);
		}
		
		public static void Error(string message, Exception exception)
		{
			string logMessage = "[ERR]"
								+ "[" + DateTime.UtcNow + "]"
			                    + "[Message: " + message + "]\n"
								+ exception;
			Logger.Write(logMessage, LogLevel.Error);
		}
		
		public static void Fatal(string message, Exception exception)
		{
			string logMessage = "[FAT]"
								+ "[" + DateTime.UtcNow + "]"
			                    + "[Message: " + message + "]\n"
								+ exception;
			Logger.Write(logMessage, LogLevel.Fatal);
		}
	}
}