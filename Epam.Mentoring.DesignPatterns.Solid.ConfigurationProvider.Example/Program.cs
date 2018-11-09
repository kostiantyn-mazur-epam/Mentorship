using System;
using System.IO;

namespace Epam.Mentoring.DesignPatterns.Solid.Example
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("ConfigurationProvider Example");
            Console.WriteLine();

            var environmentName = "Dev";
            var filePath = Directory.GetCurrentDirectory();
            var fileReader = new FileConfigReader(environmentName, filePath);
            var configContent = fileReader.Read();
            var configProvider = new CustomConfigurationProvider();
            configProvider.Initialize(configContent);
            var settings = configProvider.Get<ServiceSettings>();

            Console.WriteLine("ConnectionString={0}", settings.ConnectionString);
            Console.WriteLine("BatchSize={0}", settings.BatchSize);
            Console.WriteLine("Port={0}", settings.Port);
        }
    }
}