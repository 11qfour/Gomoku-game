using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Analytics.UserId;

namespace Gomoku
{
    public sealed class LoggerService<T> : ILoggerService<T>
    {

        private readonly IFileServices _fileService;
        private readonly string _namSpace; //путь файла куда делаем лог
        private readonly string _currentTime = DateTime.Now.ToLongTimeString();
        //время когда произошла запись
        public LoggerService(IFileServices fileService)
        {
            _fileService = fileService;
            _namSpace = typeof(T).FullName;
        }

        private string CastMessage(string message, LogLevel level, short traceId, Exception exception) //создание лога 
        {
            //
            return exception !=null ? $"{_currentTime}|{traceId}|{_namSpace}|{level.ToString()}|{message}{exception}" 
                : $"{_currentTime}|{traceId}|{_namSpace}|{level.ToString()}|{message}";
        }


        public void Log(LogLevel level, string message, short traceId = 0, Exception exception = null)
        {
            var response = CastMessage(message, level, traceId, exception);
            switch (level)
            {
                case LogLevel.Information:
                    LogInformation(response);
                    break;
                case LogLevel.Warning:
                    LogWarning(response);
                    break;
                case LogLevel.Error:
                    LogError(exception, message);
                    break;
                case LogLevel.Critical:
                    LogCritical(exception, response);
                    break;
            }
        }

        public void LogCritical(Exception ex, string message) //исключение
        {
            _fileService.WriteLog(message, ex);
        }

        public void LogError(Exception ex, string message) //исключение
        {
            _fileService.WriteLog(message, ex);
        }

        public void LogInformation(string message) //сообщение
        {
            _fileService.WriteLog(message);
        }

        public void LogWarning(string message)
        {
            _fileService.WriteLog(message);
        }

        public void Trace(string message) //собщение
        {
            _fileService.WriteLog(message);
        }
    }
}
