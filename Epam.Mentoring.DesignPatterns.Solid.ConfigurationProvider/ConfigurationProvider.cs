using Epam.Mentoring.DesignPatterns.Solid.Interfaces;

namespace Epam.Mentoring.DesignPatterns.Solid
{
    public abstract class ConfigurationProvider : IConfigurationProvider
    {
        public abstract T Get<T>()
            where T : new();

        public abstract void Initialize(string initializationSource);
    }
}