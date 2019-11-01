namespace Logging.FileOutput
{
    public static class LoggerConfigurationExtensions
    {
        public static LoggerConfiguration WriteToFile(this LoggerConfiguration configuration, string path)
        {
            configuration.AddOutputModule(new FileModule(path));
            return configuration;
        }
    }
}