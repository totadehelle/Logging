using System;
using System.Collections.Generic;
using Logging.Enums;
using Logging.Interfaces;

namespace Logging
{
	public class LoggerConfiguration
	{
		private readonly LoggerSingleton _logger;

		public LoggerConfiguration()
		{
			_logger = LoggerSingleton.Instance;
			if(_logger.IsConfigured)
				throw new Exception("Logger may be configured once only.");
		}

		public LoggerConfiguration SetMinimumLevel(LogLevel level)
		{
			_logger.MinimumLevel = level;
			return this;
		}

		public LoggerConfiguration SetOutputModules(List<IOutputModule> modules)
		{
			_logger.OutputModules.AddRange(modules);
			return this;
		}

		public ILogger CreateLogger()
		{
			_logger.IsConfigured = true;
			return _logger;
		}
	}
}