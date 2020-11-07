using System;
using TelegramWeatherBot.Settings;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramWeatherBot.Commands
{
    public abstract class Command
    {
        private string Name { get; set; }

        public abstract void Execute(Message message, TelegramBotClient client);

        public bool Contains(string command)
        {
            return command.Contains(this.Name) && command.Contains(Configs.Name);
        }
    }
}
