using System.Collections.Generic;
using Logging.Enums;

namespace Logging.Interfaces
{
	public interface ILogger
	{
		void Write(string message, LogLevel level);
	}
}