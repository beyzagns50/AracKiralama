using Microsoft.AspNetCore.Mvc;

namespace RentCar.WebUI.Controllers
{
    public class RentACarProcessController : Controller
    {
        // GET: /RentACarProcess/Create
        public IActionResult Index()
        {
            // Sayfa ilk açıldığında formu döndürür.
            return View();
        }
    }
}
