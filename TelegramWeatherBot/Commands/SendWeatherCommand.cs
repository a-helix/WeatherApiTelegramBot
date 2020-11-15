using RabbitChat;
using Telegram.Bot;
using Telegram.Bot.Types;
using Credentials;
using System.IO;

namespace TelegramWeatherBot.Commands
{
    public class SendWeatherCommand : Command
    {
        private static string _configPath = Path.Join("Configs", "ApiConfigs.json");
        private static JsonFileContent _configs = new JsonFileContent(_configPath);
        Publisher publisher = new Publisher(_configs.Value("RabbitUrl").ToString(), 
                                                       _configs.Value("RabbitLogin").ToString(),
                                                       _configs.Value("RabbitPassword").ToString());
        Consumer consumer = new Consumer(_configs.Value("RabbitUrl").ToString(),
                                                       _configs.Value("RabbitLogin").ToString(),
                                                       _configs.Value("RabbitPassword").ToString());
        public override async void Execute(Message message, TelegramBotClient client)
        {
            
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            string response;
            publisher.SendQueue(_configs.Value("RabbitQueue").ToString(), message.ToString());
            response = consumer.ReceiveQueue(message.ToString());
            await client.SendTextMessageAsync(0, response, replyToMessageId:0);
        }
    }
}
