using System;

namespace ConfigurationProvider.Example
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("ConfigurationProvider Example");
            Console.WriteLine();

            var environmentName = "Dev";
            var fileReader = new FileConfigReader(environmentName);
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
