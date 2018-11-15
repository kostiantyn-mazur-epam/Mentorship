using System;
using System.IO;
using Epam.Mentoring.DesignPatterns.Solid.Interfaces;

namespace Epam.Mentoring.DesignPatterns.Solid
{
    public class FileConfigReader : IConfigReader
    {
        private readonly string _environmentName;
        private readonly string _filePath;
        private const string _fileExtension = ".cfg";

        public FileConfigReader(string environmentName, string filePath)
        {
            if (environmentName == null)
            {
                throw new ArgumentNullException(nameof(environmentName));
            }

            if (filePath == null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            _environmentName = environmentName;
            _filePath = filePath;
        }

        public string Read()
        {
            var fileName = _environmentName + _fileExtension;
            var filePath = Path.Combine(_filePath, fileName);

            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath))
                {
                    return reader.ReadToEnd();
                }
            }

            return null;
        }
    }
}