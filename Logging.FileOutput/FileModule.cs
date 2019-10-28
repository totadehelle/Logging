using System;
using Logging.Interfaces;

namespace Logging.FileOutput
{
	class FileModule : IOutputModule
	{
		private readonly string _path;
		public FileModule(string path)
		{
			_path = path;
		}
		public void Write(string message)
		{
			throw new NotImplementedException();
		}
	}
}
