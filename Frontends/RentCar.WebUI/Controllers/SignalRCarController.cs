using Microsoft.AspNetCore.Mvc;

namespace RentCar.WebUI.Controllers
{
    public class SignalRCarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
