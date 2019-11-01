using System;
using System.Collections.Generic;

namespace Logging
{
    public class Logger : ILogger
	{
		internal LogLevel MinimumLevel = LogLevel.Information;
		internal List<IOutputModule> OutputModules = new List<IOutputModule>();
        internal bool IsDebugOutputOn = false;

        internal Logger()
        {
            
        }
        
        public void Write(string message, LogLevel level)
		{
			if(level < MinimumLevel)
				return;
            if (IsDebugOutputOn)
                System.Diagnostics.Debug.Write(message);
            foreach (var module in OutputModules)
			{
				module.Write(message);
			}
		}

        public void Flush()
        {
            foreach (var module in OutputModules)
            {
                if (module is IDisposable disposableModule)
                {
                    disposableModule.Dispose();
                }
            }
            OutputModules.Clear();
        }
    }
}
