using System;
using System.Threading.Tasks;
using Credentials;
using Microsoft.AspNetCore.Mvc;
using RabbitChat;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramWeatherBot.Models;


namespace TelegramWeatherBot.Controllers
{
    [Route("subscribe/location={location};frequency={frequency}")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        static JsonFileContent configs = new JsonFileContent("Configs.json");
        Publisher publisher = new Publisher(
            Convert.ToString(configs.Value("RabbitMQ")),
            Convert.ToString(configs.Value("RabbitLogin")),
            Convert.ToString(configs.Value("RabbitQueue"))
            );

        public OkResult Subscribe(TelegramBotClient botClient, [FromQuery] string location, [FromQuery] string frequency)
        {
            string message = string.Join(";", botClient.BotId, location, frequency);
            publisher.SendQueue(
                Convert.ToString(configs.Value("RabbitQueue")),
                message
                );
            return Ok();
        }
    }
}
