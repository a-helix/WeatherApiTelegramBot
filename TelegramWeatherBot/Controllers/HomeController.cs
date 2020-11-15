using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TelegramWeatherBot.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return NotFound();
        }
    }
}
