using System;
using System.IO;

namespace Epam.Mentoring.MemoryManagement.Disposable.CodeFix
{
    public class MemoryStreamLogger : IDisposable
    {
        private FileStream _memoryStream;
        private StreamWriter _streamWriter;

        public MemoryStreamLogger()
        {
            _memoryStream = new FileStream(@"\log.txt", FileMode.OpenOrCreate);
            _streamWriter = new StreamWriter(_memoryStream);
        }

        public void Dispose()
        {
            _streamWriter.Dispose();
        }

        public void Log(string message)
        {
            _streamWriter.Write(message);
        }
    }
}