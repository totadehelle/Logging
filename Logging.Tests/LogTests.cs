using System;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Logging.Tests
{
    public class LogTests
    {
        [Test]
        public void PropertyLogger_Always_ReturnsGlobalLoggerContextInstance()
        {
            Mock<ILogger> logger = new Mock<ILogger>();
            Mock<ILogMessage> message = new Mock<ILogMessage>();
            GlobalLoggerContext.Instance = logger.Object;

            Log.Logger.Write(message.Object);

            logger.Verify(l => l.Write(It.IsAny<ILogMessage>()), Times.AtLeastOnce);
        }
        
        [Test]
        public void GetBuilder_LoggerIsNotConfigured_ReturnsLoggerConfiguration()
        {
            GlobalLoggerContext.IsConfigured = false;

            var result = Log.GetBuilder();

            Assert.That(result, Is.InstanceOf<LoggerConfiguration>());
        }

        [Test]
        public void GetBuilder_LoggerIsConfigured_ThrowsLoggerConfiguringForbiddenException()
        {
            GlobalLoggerContext.IsConfigured = true;

            Assert.Throws<LoggerConfiguringForbiddenException>(() => Log.GetBuilder());
        }

        #region LogLevelsTests
        [Test]
        public void Verbose_Always_SendsMessageWithVerboseLevel()
        {
            Mock<ILogger> logger = new Mock<ILogger>();
            GlobalLoggerContext.Instance = logger.Object;

            Log.Verbose("message");

            logger.Verify(l => l.Write(
                It.Is<ILogMessage>(p => p.LevelOfSeverity == LogLevel.Verbose)), 
                Times.AtLeastOnce);
        }
        [Test]
        public void Debug_Always_SendsMessageWithDebugLevel()
        {
            Mock<ILogger> logger = new Mock<ILogger>();
            GlobalLoggerContext.Instance = logger.Object;

            Log.Debug("message");

            logger.Verify(l => l.Write(
                    It.Is<ILogMessage>(p => p.LevelOfSeverity == LogLevel.Debug)),
                Times.AtLeastOnce);
        }
        [Test]
        public void Information_Always_SendsMessageWithInformationLevel()
        {
            Mock<ILogger> logger = new Mock<ILogger>();
            GlobalLoggerContext.Instance = logger.Object;

            Log.Information("message");

            logger.Verify(l => l.Write(
                    It.Is<ILogMessage>(p => p.LevelOfSeverity == LogLevel.Information)),
                Times.AtLeastOnce);
        }
        [Test]
        public void Warning_Always_SendsMessageWithWarningLevel()
        {
            Mock<ILogger> logger = new Mock<ILogger>();
            GlobalLoggerContext.Instance = logger.Object;

            Log.Warning("message");

            logger.Verify(l => l.Write(
                    It.Is<ILogMessage>(p => p.LevelOfSeverity == LogLevel.Warning)),
                Times.AtLeastOnce);
        }
        [Test]
        public void Error_Always_SendsMessageWithErrorLevel()
        {
            Mock<ILogger> logger = new Mock<ILogger>();
            GlobalLoggerContext.Instance = logger.Object;

            Log.Error("message", new Exception());

            logger.Verify(l => l.Write(
                    It.Is<ILogMessage>(p => p.LevelOfSeverity == LogLevel.Error), 
                    It.IsAny<Exception>()),
                Times.AtLeastOnce);
        }
        [Test]
        public void Fatal_Always_SendsMessageWithFatalLevel()
        {
            Mock<ILogger> logger = new Mock<ILogger>();
            GlobalLoggerContext.Instance = logger.Object;

            Log.Fatal("message", new Exception());

            logger.Verify(l => l.Write(
                    It.Is<ILogMessage>(p => p.LevelOfSeverity == LogLevel.Fatal),
                    It.IsAny<Exception>()),
                Times.AtLeastOnce);
        }
        #endregion

        [Test]
        public void Close_Always_CallsFlushMethodOfOldLoggerObject()
        {
            Mock<ILogger> logger = new Mock<ILogger>();
            GlobalLoggerContext.Instance = logger.Object;

            Log.Close();

            logger.Verify(l => l.Flush(), Times.AtLeastOnce);
        }
    }
}