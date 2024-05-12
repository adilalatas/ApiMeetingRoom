using NLog;
using Services.Contracts;


namespace Services
{
    public class LoggerManager : ILoggerService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        public void LogDebug(string message) => logger.Debug(message);
        public void LogError(string message) => logger.Error(message);
        public void LogInFo(string message) => logger.Info(message);
        public void LogWarnig(string message) => logger.Warn(message);

    }
}
