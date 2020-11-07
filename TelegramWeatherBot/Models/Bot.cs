using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramWeatherBot.Settings;
using TelegramWeatherBot.Commands;

namespace TelegramWeatherBot.Models
{
    public class Bot
    {
        private TelegramBotClient _client;
        private List<Command> commandsList;
        public IReadOnlyList<Command> Commands { get => commandsList.AsReadOnly(); }

        public Bot()
        {
            _client = new TelegramBotClient(Configs.Key);
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

            var hook = string.Format(Configs.Url, "api/message/update");
            await _client.SetWebhookAsync(hook);
            return _client;
        }
    }
}
