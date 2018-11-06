using System.Configuration;

namespace Epam.Mentoring.MemoryManagement.GC.Zoo
{
    public static class AppSettings
    {
        public static bool IsLoggingEnabled
        {
            get
            {
                return string.Equals(ConfigurationManager.AppSettings["isLoggingEnabled"], "true");
            }
        } 
    }
}