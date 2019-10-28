using System.Collections.Generic;
using Logging.Enums;

namespace Logging.Interfaces
{
	public interface ILogger
	{
		LogLevel MinimumLevel { get; set; }
		Dictionary<OutputModule, IOutputModule> OutputModules { get; set; }
		bool IsConfigured { get; set; }

		LoggerConfiguration Configure();
		void Write(string message);
	}
}