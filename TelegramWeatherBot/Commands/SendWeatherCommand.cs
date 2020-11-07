using RabbitChat;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramWeatherBot.Settings;

namespace TelegramWeatherBot.Commands
{
    public class SendWeatherCommand : Command
    {
        Publisher publisher = new RabbitChat.Publisher(Configs.RabbitUrl, Configs.RabbitLogin, Configs.RabbitPassword);
        Consumer consumer = new RabbitChat.Consumer(Configs.RabbitUrl, Configs.RabbitLogin, Configs.RabbitPassword);

        public override async void Execute(Message message, TelegramBotClient client)
        {
            
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            string response;
            publisher.SendQueue(Configs.RabbitQueue, message.ToString());
            response = consumer.ReceiveQueue(message.ToString());
            await client.SendTextMessageAsync(0, response, replyToMessageId:0);
        }
    }
}
