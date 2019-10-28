using System;
using System.Runtime.CompilerServices;
using Logging.Enums;
using Logging.Interfaces;

namespace Logging
{
	public class LoggerConfiguration
	{
		public readonly ILogger Logger;
		public ModuleSetter WriteTo { get; }
		public LoggerConfiguration()
		{
			Logger = Log.Logger;
			if(Logger.IsConfigured)
				throw new Exception("Logger may be configured once only.");
			Logger.IsConfigured = true;
			WriteTo = new ModuleSetter(this);
		}

		public LoggerConfiguration SetMinimumLevel(LogLevel level)
		{
			Logger.MinimumLevel = level;
			return this;
		}
	}
}