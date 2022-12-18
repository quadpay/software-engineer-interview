using NLog;

namespace InstallmentCalculationAPI.Log
{
    /// <summary>
    /// Core logic for different log related methods
    /// </summary>
    public class LogNLog : ILog
    {
        private static NLog.ILogger logger = LogManager.GetCurrentClassLogger();
        public LogNLog()
        {
        }
        /// <summary>
        /// Log information message
        /// </summary>
        /// <param name="message">message</param>
        public void Information(string message)
        {
            logger.Info(message);
        }

        /// <summary>
        /// Log warning message
        /// </summary>
        /// <param name="message">message</param>
        public void Warning(string message)
        {
            logger.Warn(message);
        }

        /// <summary>
        /// Log debugging related message
        /// </summary>
        /// <param name="message">message</param>
        public void Debug(string message)
        {
            logger.Debug(message);
        }

        /// <summary>
        /// Log error message
        /// </summary>
        /// <param name="message">message</param>
        public void Error(string message)
        {
            logger.Error(message);
        }
    }
}
