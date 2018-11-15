namespace Epam.Mentoring.DesignPatterns.Solid.Interfaces
{
    public interface IConfigurationProvider
    {
        T Get<T>() 
            where T : new();
    }
}