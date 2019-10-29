using System;
using System.Collections.Generic;
using Logging.Enums;
using Logging.Interfaces;

namespace Logging
{
	public class LoggerSingleton : ILogger
	{
		internal LogLevel MinimumLevel { get; set; } = LogLevel.Information;
		internal List<IOutputModule> OutputModules { get; set; } = new List<IOutputModule>();
		
		internal static LoggerSingleton Instance { get; }

		internal bool IsConfigured { get; set; } = false;

		static LoggerSingleton()
		{
			Instance = new LoggerSingleton();
		}

		private LoggerSingleton()
		{
			
		}

		
		public void Write(string message, LogLevel level)
		{
			System.Diagnostics.Debug.Write(message);
			if(level < MinimumLevel)
				return;
			foreach (var module in OutputModules)
			{
				module.Write(message);
			}
		}
	}

}
