namespace ConfigurationProvider
{
    public sealed class ServiceSettings
    {
        public string ConnectionString
        {
            get; set;
        }

        public int Port
        {
            get; set;
        }

        public int BatchSize
        {
            get; set;
        }
    }
}