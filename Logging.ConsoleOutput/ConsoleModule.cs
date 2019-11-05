using System;

namespace Logging.ConsoleOutput
{
	public class ConsoleModule : IOutputModule
	{
        internal ConsoleModule()
        {
            
        }
        public void Write(string message)
		{
            try
            {
                Console.WriteLine(message);
            }
            catch (Exception e)
            {
                throw new LoggingFailedException("Logging to console failed. " + e.Message);
            }
		}
	}
}