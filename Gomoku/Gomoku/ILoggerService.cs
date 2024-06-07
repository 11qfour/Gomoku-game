using Microsoft.Extensions.Logging;
using System;

namespace Gomoku
{
    public interface ILoggerService<T>
    {
        void Log(LogLevel level, string message, short traceId = 0, Exception exception = null);
        void Trace(string message); //написать детализированное сообщение

        void LogInformation(string message); //вывод общей информации 

        void LogWarning(string Messge); //сообщения несут некоторые предупреждения

        void LogError(Exception ex, string message); // ошибки возникшие при текущей опекрации и не могут быть обработаны

        void LogCritical(Exception ex, string message); //ошиби требуют немедленной обработки
    }
}