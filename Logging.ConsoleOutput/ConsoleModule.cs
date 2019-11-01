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
			Console.WriteLine(message);
		}
	}
}