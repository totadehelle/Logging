using Logging.Enums;

namespace Logging.FileOutput
{
	public static class ModuleSetterFileExtension
	{
		public static LoggerConfiguration File(this ModuleSetter setter, string path)
		{
			setter.AddModule(OutputModule.File, new FileModule(path));
			return setter.Configuration;
		}
	}
}