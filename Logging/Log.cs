using System;
using System.Threading;

namespace Logging
{
	public static class Log
    {
        static Log()
        {
            
        }

        internal static ILogger Logger { get; } = GlobalLogger.Instance;

        /// <summary>
        /// Start logger configuration process.
        /// </summary>
        /// <returns></returns>
        public static LoggerConfiguration GetBuilder()
        {
            if (GlobalLogger.IsConfigured)
                throw new Exception("Logger may be configured once only.");
            return new LoggerConfiguration();
        }
        
        /// <summary>
        /// Log message with Verbose level of severity
        /// </summary>
        public static void Verbose(string message)
		{
			string logMessage = "[VRB]"
								+ "[UTC " + DateTime.UtcNow + "]"
			                    + "[Message: " + message + "]";
			Logger.Write(logMessage, LogLevel.Verbose);
		}

        /// <summary>
        /// Log message with Debug level of severity
        /// </summary>
        public static void Debug(string message)
		{
			string logMessage = "[DBG]"
								+ "[UTC " + DateTime.UtcNow + "]"
			                    + "[Message: " + message + "]";
			Logger.Write(logMessage, LogLevel.Debug);
		}

        /// <summary>
        /// Log message with Information level of severity
        /// </summary>
        public static void Information(string message)
		{
			string logMessage = "[INF]"
								+ "[UTC " + DateTime.UtcNow + "]"
			                    + "[Message: " + message + "]";
			Logger.Write(logMessage, LogLevel.Information);
		}

        /// <summary>
        /// Log message with Warning level of severity
        /// </summary>
        public static void Warning(string message)
		{
			string logMessage = "[WRN]"
								+ "[UTC " + DateTime.UtcNow + "]"
			                    + "[Message: " + message + "]";
			Logger.Write(logMessage, LogLevel.Warning);
		}

        /// <summary>
        /// Log message with Error level of severity
        /// </summary>
        public static void Error(string message, Exception exception)
		{
			string logMessage = "[ERR]"
								+ "[UTC " + DateTime.UtcNow + "]"
			                    + "[Message: " + message + "]\n"
								+ exception;
			Logger.Write(logMessage, LogLevel.Error);
		}

        /// <summary>
        /// Log message with Fatal level of severity
        /// </summary>
        public static void Fatal(string message, Exception exception)
		{
			string logMessage = "[FAT]"
								+ "[UTC " + DateTime.UtcNow + "]"
			                    + "[Message: " + message + "]\n"
								+ exception;
			Logger.Write(logMessage, LogLevel.Fatal);
		}

        /// <summary>
        /// Free all disposable resources and delete links to output modules from logger.
        /// </summary>
        public static void Close()
        {
            var oldLogger = Logger;
            GlobalLogger.Instance = Interlocked.Exchange(ref GlobalLogger.Instance, new DefaultLogger());
            oldLogger.Flush();
        }
	}
}