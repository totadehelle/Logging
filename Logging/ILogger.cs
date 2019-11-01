namespace Logging
{
	public interface ILogger
	{
		void Write(string message, LogLevel level);
        void Flush();
    }
}