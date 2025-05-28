using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace RentCar.WebUI.Areas.Admin.Controllers
{
    public class AdminCarController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public AdminCarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SetAvailable(int id, bool available)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PutAsync($"https://localhost:44308/api/RentACars/SetAvailable/{id}?available={available}", null);
            // Başarılıysa listeye dön
            return RedirectToAction("Index");
        }
    }
}
