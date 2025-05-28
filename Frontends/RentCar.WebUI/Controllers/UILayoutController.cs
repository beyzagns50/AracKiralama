using Microsoft.AspNetCore.Mvc;

namespace RentCar.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
