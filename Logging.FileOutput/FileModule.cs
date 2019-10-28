using System;
using System.IO;
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
			using (StreamWriter writer = File.AppendText(_path))
			{
				writer.WriteLine(message);
			};
		}
	}
}
