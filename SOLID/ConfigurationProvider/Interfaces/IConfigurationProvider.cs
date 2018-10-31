namespace ConfigurationProvider
{
    public interface IConfigurationProvider
    {
        T Get<T>() 
            where T : new();
    }
}