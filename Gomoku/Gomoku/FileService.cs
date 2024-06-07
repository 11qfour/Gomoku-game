using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    public sealed class FileService : IFileServices
    {
        private const string PATH = @"C:\Users\user\Desktop\proj\Gomoku\Gomoku\Gomoku\Logs\MyLogs.txt";
        public async Task WriteLog(string message, Exception ex = null)
        {
            using (StreamWriter sw = new StreamWriter(PATH, true, Encoding.Default))
            {
                await sw.WriteLineAsync(message);
            }
        }

        public async Task ReadLogs()
        {
            using (StreamReader sr = new StreamReader(PATH))
            {
                Console.WriteLine(await sr.ReadToEndAsync());
            }
        }
    }
}
