using System;
using System.Collections.Generic;
using Logging.Enums;
using Logging.Interfaces;

namespace Logging
{
	public class LoggerSingleton : ILogger
	{
		public LogLevel MinimumLevel { get; set; } = LogLevel.Information;
		public Dictionary<OutputModule, IOutputModule> OutputModules { get; set; } = new Dictionary<OutputModule, IOutputModule>();

		public static LoggerSingleton Instance { get; }

		public bool IsConfigured { get; set; } = false;

		static LoggerSingleton()
		{
			Instance = new LoggerSingleton();
		}

		private LoggerSingleton()
		{
			
		}

		public LoggerConfiguration Configure()
		{
			return new LoggerConfiguration();
		}

		public void Write(string message)
		{
			foreach (var module in OutputModules.Values)
			{
				module.Write(message);
			}
		}
	}

}
