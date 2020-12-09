using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using TelegramWeatherBot.Models;

namespace TelegramWeatherBot.Controllers
{
    [Route("api/message/update")]
    [ApiController]
    public class MessageController : ControllerBase
    {

        public async Task<OkResult> Update([FromBody] Update update)
        {
            Bot bot = new Bot();
            var commands = bot.Commands;
            var message = update.Message;
            var client = await bot.Get();

            foreach(var command in commands)
            {
                if(command.Contains(message.Text))
                {
                    command.Execute(message, client);
                    break;
                }
            }
            return Ok();
        }
    }
}
