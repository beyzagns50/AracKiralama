using Microsoft.AspNetCore.Mvc;

namespace RentCar.WebUI.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
