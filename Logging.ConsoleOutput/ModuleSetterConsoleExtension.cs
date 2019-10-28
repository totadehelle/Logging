using Logging.Enums;

namespace Logging.ConsoleOutput
{
	public static class ModuleSetterConsoleExtension
	{
		public static LoggerConfiguration Console(this ModuleSetter setter)
		{
			setter.AddModule(OutputModule.Console, new ConsoleModule());
			return setter.Configuration;
		}
	}
}