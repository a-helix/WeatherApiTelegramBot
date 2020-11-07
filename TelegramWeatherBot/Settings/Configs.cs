using Credentials;

namespace TelegramWeatherBot.Settings
{
    public static class Configs
    {
        private static JsonFileContent _configs = new JsonFileContent("Configs.json");
        public static readonly string Url = (string)_configs.Value("Url");
        public static readonly string Key = (string)_configs.Value("ApiKey");
        public static readonly string Name = (string)_configs.Value("Name");
        public static readonly string RabbitUrl = (string)_configs.Value("RabbitMQ");
        public static readonly string RabbitLogin = (string)_configs.Value("RabbitLogin");
        public static readonly string RabbitPassword = (string)_configs.Value("RabbitPassword");
        public static readonly string RabbitQueue = (string)_configs.Value("RabbitQueue");
    }
}
