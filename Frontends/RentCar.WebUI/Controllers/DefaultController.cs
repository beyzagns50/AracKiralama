using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RentCar.Dto.LocationDtos;

namespace RentCar.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            // Alınacak lokasyonlar için API çağrısı
            var responseMessage = await client.GetAsync("https://localhost:44308/api/Locations");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);

                var values2 = values.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.LocationID.ToString()
                }).ToList();

                ViewBag.v = values2;
            }
            else
            {
                ViewBag.v = new List<SelectListItem>(); // Avoid null if the API call fails
            }

            // Teslim edilecek lokasyonlar için API çağrısı
            var returnResponseMessage = await client.GetAsync("https://localhost:44308/api/Locations");
            if (returnResponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await returnResponseMessage.Content.ReadAsStringAsync();
                var returnValues = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);

                var returnValues2 = returnValues.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.LocationID.ToString()
                }).ToList();

                ViewBag.ReturnLocations = returnValues2;
            }
            else
            {
                ViewBag.ReturnLocations = new List<SelectListItem>(); // Avoid null if the API call fails
            }

            return View();
        }
        [HttpPost]
        public IActionResult Index(
            string pickup_date,
            string return_date,
            string pickup_time,
            string return_time,
            string LocationID,
            string ReturnLocationID)
        {
            if (string.IsNullOrEmpty(pickup_date) || string.IsNullOrEmpty(return_date))
            {
                ModelState.AddModelError("", "Tarih alanları boş olamaz.");
                return View();
            }

            DateTime pickDate = DateTime.ParseExact(pickup_date, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime offDate = DateTime.ParseExact(return_date, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);

            TempData["bookpickdate"] = pickDate.ToString("yyyy-MM-dd");
            TempData["bookoffdate"] = offDate.ToString("yyyy-MM-dd");
            TempData["timepick"] = pickup_time;
            TempData["timeoff"] = return_time;
            TempData["locationID"] = LocationID;
            TempData["returnLocationID"] = ReturnLocationID;

            return RedirectToAction("Index", "RentACarList");
        }
    }
}
