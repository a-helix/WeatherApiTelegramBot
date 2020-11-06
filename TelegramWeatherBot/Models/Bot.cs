using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramWeatherBot.Models
{
    public class Bot
    {
        private TelegramBotClient client = new TelegramBotClient();

        public async Task<TelegramBotClient> Get()
        {
            if(client != null)
            {
                return client;
            }
        }
    }
}
