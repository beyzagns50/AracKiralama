using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentCar.Dto.ReservationDtos;
using RentCar.Dto.LocationDtos;

namespace RentCar.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            // Rezervasyonlarý çek
            var response = await client.GetAsync("https://localhost:44308/api/Reservations");
            var jsonData = await response.Content.ReadAsStringAsync();
            var reservations = JsonConvert.DeserializeObject<List<ResultReservationDto>>(jsonData);

            // Lokasyonlarý çek
            var locationResponse = await client.GetAsync("https://localhost:44308/api/Locations");
            var locationJson = await locationResponse.Content.ReadAsStringAsync();
            var locations = JsonConvert.DeserializeObject<List<ResultLocationDto>>(locationJson);

            // Dictionary oluþtur
            var locationDict = locations.ToDictionary(x => x.LocationID, x => x.Name);
            ViewBag.LocationDict = locationDict;

            return View(reservations);
        }
    }
}