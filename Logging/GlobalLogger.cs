namespace Logging
{
    internal static class GlobalLogger
    {
        static GlobalLogger()
        {
            
        }
        
        internal static ILogger Instance = new DefaultLogger();
        internal static bool IsConfigured = false;
    }
}