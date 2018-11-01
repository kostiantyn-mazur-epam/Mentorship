using System;
using System.IO;

namespace ConfigurationProvider
{
    public class FileConfigReader : IConfigReader
    {
        private readonly string _environmentName;
        private readonly string _filePath;
        private readonly string _fileExtension;

        public FileConfigReader(string environmentName, string filePath, string fileExtension)
        {
            if (environmentName == null)
            {
                throw new ArgumentNullException(nameof(environmentName));
            }

            if (filePath == null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            if (fileExtension == null)
            {
                throw new ArgumentNullException(nameof(fileExtension));
            }

            _environmentName = environmentName;
            _filePath = filePath;
            _fileExtension = fileExtension;
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