using Microsoft.AspNetCore.Mvc;

namespace RentCar.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminRentACarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
