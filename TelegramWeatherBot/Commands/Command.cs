using Credentials;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramWeatherBot.Commands
{
    public abstract class Command
    {
        private string Name { get; set; }
        private static string _configPath = Path.Join("Configs", "ApiConfigs.json");
        private JsonFileContent _configs = new JsonFileContent(_configPath);

        public abstract void Execute(Message message, TelegramBotClient client);

        public bool Contains(string command)
        {
            return command.Contains(this.Name) && command.Contains(_configs.Value("Name").ToString());
        }
    }
}
