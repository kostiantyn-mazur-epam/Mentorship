using System;
using System.IO;

namespace ConfigurationProvider
{
    public class FileConfigReader : IConfigReader
    {
        private string _environmentName;

        public FileConfigReader(string environmentName)
        {
            if (environmentName == null)
            {
                throw new ArgumentNullException(nameof(environmentName));
            }

            _environmentName = environmentName;
        }

        public string Read()
        {
            var fileName = string.Format("{0}.cfg", _environmentName);
            var path = Directory.GetCurrentDirectory();
            var filePath = Path.Combine(path, fileName);

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