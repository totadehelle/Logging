using System;
using System.Threading;

namespace Logging
{
	public class LoggerConfiguration
	{
		private readonly Logger _logger;

		internal LoggerConfiguration()
		{
            _logger = new Logger();
		}

        /// <summary>
        /// Set minimum severity level of events to be logged. A message will be logged if it
        /// has the same or higher level of severity. Otherwise it will be ignored.
        /// Default level is LogLevel.Information.
        /// </summary>
        public LoggerConfiguration SetMinimumLevel(LogLevel level)
		{
			_logger.MinimumLevel = level;
			return this;
		}

        /// <summary>
        /// Add new output module for logger.
        /// </summary>
        public LoggerConfiguration AddOutputModule(IOutputModule module)
        {
            _logger.OutputModules.Add(module);
            return this;
        }

        /// <summary>
        /// Turn on/off writing log messages to IDE console for debugging (turned off on default)
        /// </summary>
        public LoggerConfiguration SetDebugOutput(bool isTurnedOn)
        {
            _logger.IsDebugOutputOn = isTurnedOn;
            return this;
        }

		/// <summary>
        /// Finish logger configuration process and save all the settings.
        /// </summary>
        public void BuildLogger()
		{
            if (GlobalLoggerContext.IsConfigured)
                throw new Exception("Logger may be configured once only.");
            GlobalLoggerContext.IsConfigured = true;
            Volatile.Write(ref GlobalLoggerContext.Instance, _logger);
        }
	}
}