using Credentials;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramWeatherBot.Commands;

namespace TelegramWeatherBot.Models
{
    public class Bot
    {
        private TelegramBotClient _client;
        private List<Command> commandsList;
        private static string _configPath = Path.Join("Configs", "ApiConfigs.json");
        private JsonFileContent _configs = new JsonFileContent(_configPath);

        public IReadOnlyList<Command> Commands { get => commandsList.AsReadOnly(); }

        public Bot()
        {
            _client = new TelegramBotClient(_configs.Value("Key").ToString());
        }

        public async Task<TelegramBotClient> Get()
        {
            commandsList = new List<Command>()
            {
                {new SendWeatherCommand() }
            };

            if(_client != null)
            {
                return _client;
            }

            var hook = string.Format(_configs.Value("Url").ToString(), "api /message/update");
            await _client.SetWebhookAsync(hook);
            return _client;
        }
    }
}
