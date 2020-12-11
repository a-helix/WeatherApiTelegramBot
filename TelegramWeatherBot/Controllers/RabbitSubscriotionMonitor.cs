using Credentials;
using RabbitChat;
using TelegramWeatherBot.Models;

namespace TelegramWeatherBot.Controllers
{
    public class RabbitSubscriotionMonitor
    {
        private Consumer _consumer;
        private JsonFileContent _config;
        private string _queueKey;

        public RabbitSubscriotionMonitor(string configPath)
        {
            _config = new JsonFileContent(configPath);
            _consumer = new Consumer(
                _config.Value("RabbitMQ").ToString(),
                _config.Value("RabbitLogin").ToString(),
                _config.Value("RabbitPassword").ToString()
                );
            _queueKey = _config.Value("RabbitQueue").ToString();
            _bot = new Bot();
        }

        public void ListenQueue()
        {
            while(true)
            {
                string feedback = _consumer.ReceiveQueue(_queueKey);
                if (feedback == null)
                    continue;
//Fix it
                _bot.SendTextMessage("@blablavla", "test message");
            }
        }
    }
}
