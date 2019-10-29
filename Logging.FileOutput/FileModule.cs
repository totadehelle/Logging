using System;
using System.IO;
using Logging.Interfaces;

namespace Logging.FileOutput
{
	public class FileModule : IOutputModule
	{
		private readonly string _path;
		public FileModule(string path)
		{
			_path = path;
		}
		public void Write(string message)
		{
			var actualPath = GetPathToLogfile(_path);
			var directory = Path.GetDirectoryName(actualPath);
			if (!(String.IsNullOrWhiteSpace(directory) || directory == ""))
			{
				if (!Directory.Exists(directory))
				{
					Directory.CreateDirectory(directory);
				}
			}
			using (StreamWriter writer = File.AppendText(actualPath))
			{
				writer.WriteLine(message);
			};
		}

		private string GetPathToLogfile(string path)
		{
			string date = DateTime.UtcNow.Date.ToString("yyyyMMdd");
			var directory = Path.GetDirectoryName(path);
			var newFileName = Path.GetFileNameWithoutExtension(path) + date + Path.GetExtension(path);
			var newPath = Path.Combine(directory ?? "", newFileName);
			return newPath;
		}
	}
}
