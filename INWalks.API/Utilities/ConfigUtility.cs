namespace INWalks.API.Utilities
{
    public static class ConfigUtility
    {
        static IConfiguration _configuration;
        public static void Initialize(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static string GetConfig(string key)
        {
            return _configuration[key];
        }
    }
}
