namespace Logging.ConsoleOutput
{
    public static class LoggerConfigurationExtensions
    {
        /// <summary>
        /// Add writing log events to <see cref="System.Console"/>.
        /// </summary>
        public static LoggerConfiguration WriteToConsole(this LoggerConfiguration configuration)
        {
            configuration.AddOutputModule(new ConsoleModule());
            return configuration;
        }
    }
}