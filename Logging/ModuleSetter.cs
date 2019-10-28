using Logging.Enums;
using Logging.Interfaces;

namespace Logging
{
	public class ModuleSetter
	{
		public LoggerConfiguration Configuration;
		
		public ModuleSetter(LoggerConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void AddModule(OutputModule key, IOutputModule value)
		{
			if (!Configuration.Logger.OutputModules.ContainsKey(key))
			{
				Configuration.Logger.OutputModules.Add(key, value);
			}
		}
	}
}