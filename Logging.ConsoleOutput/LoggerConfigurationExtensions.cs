namespace Logging.ConsoleOutput
{
    public static class LoggerConfigurationExtensions
    {
        public static LoggerConfiguration WriteToConsole(this LoggerConfiguration configuration)
        {
            configuration.AddOutputModule(new ConsoleModule());
            return configuration;
        }
    }
}