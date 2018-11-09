namespace Epam.Mentoring.DesignPatterns.Solid
{
    public interface IConfigurationProvider
    {
        T Get<T>() 
            where T : new();
    }
}