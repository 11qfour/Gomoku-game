using System;
using System.Threading.Tasks;

namespace Gomoku
{
    public interface IFileServices
    {
        Task WriteLog(string message, Exception ex = null);
    }
}