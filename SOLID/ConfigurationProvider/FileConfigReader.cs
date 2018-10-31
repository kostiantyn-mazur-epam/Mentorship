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

            if (File.Exists(fileName))
            {
                using (var reader = new StreamReader(fileName))
                {
                    return reader.ReadToEnd();
                }
            }

            return null;
        }
    }
}