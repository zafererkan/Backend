using NLog;
using System;

namespace Sobis.Core.Logging
{
    public class NLogLoggerManager : ILoggerService
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        public void LogError(Exception Exception, string source = null)
        {
            if (Exception.InnerException != null)
            {
                if (string.IsNullOrEmpty(source))
                {
                    logger.Error("Hata Kaynağı : ");
                    logger.Error(source);
                }
                logger.Error("İstisna Türü: ");
                logger.Error(Exception.InnerException.GetType().ToString());
                logger.Error("İstisna Mesajı: ");
                logger.Error(Exception.InnerException.Message);
                logger.Error("İstisna Kaynağı: ");
                logger.Error(Exception.InnerException.Source);
                if (Exception.InnerException.StackTrace != null)
                {
                    logger.Error("Yığın: ");
                    logger.Error(Exception.InnerException.StackTrace);
                }
            }
            if (!string.IsNullOrEmpty(source))
            {
                logger.Error("Hata Kaynağı : ");
                logger.Error(source);
            }
            logger.Error("İstisna Türü: ");
            logger.Error(Exception.GetType().ToString());
            logger.Error("İstisna Mesajı: " + Exception.Message);
            logger.Error("Kaynak İzi: ");
            if (Exception.StackTrace != null)
            {
                logger.Error(Exception.StackTrace);
            }
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogWarning(string message)
        {
            logger.Warn(message);
        }
    }
}
