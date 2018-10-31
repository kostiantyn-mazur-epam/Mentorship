namespace ConfigurationProvider
{
    public abstract class ConfigurationProvider : IConfigurationProvider
    {
        public abstract T Get<T>()
            where T : new();

        public abstract void Initialize(string initializationSource);
    }
}