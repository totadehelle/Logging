using System;
using Logging.Interfaces;

namespace Logging.ConsoleOutput
{
	public class ConsoleModule : IOutputModule
	{
		public void Write(string message)
		{
			Console.WriteLine(message);
		}
	}
}