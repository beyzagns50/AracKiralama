using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using RentCar.Dto.CarFeatureDtos;
using RentCar.Dto.CategoryDtos;
using RentCar.Dto.FeatureDtos;

namespace RentCar.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarFeatureDetail")]
    public class AdminCarFeatureDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index/{id}")]
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44308/api/CarFeatures?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> resultCarFeatureByCarIdDto)
        {
            foreach (var item in resultCarFeatureByCarIdDto)
            {
                var client = _httpClientFactory.CreateClient();
                if (item.Available)
                {
                    await client.GetAsync("https://localhost:44308/api/CarFeatures/CarFeatureChangeAvailableToTrue?id=" + item.CarFeatureID);
                }
                else
                {
                    await client.GetAsync("https://localhost:44308/api/CarFeatures/CarFeatureChangeAvailableToFalse?id=" + item.CarFeatureID);
                }
            }
            return RedirectToAction("Index", "AdminCar");
        }

        [Route("CreateFeatureByCarId/{id}")]
        [HttpGet]
        public async Task<IActionResult> CreateFeatureByCarId(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44308/api/Features");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                ViewBag.CarId = id;
                return View(values);
            }
            ViewBag.CarId = id;
            return View();
        }

        [Route("CreateFeatureByCarId/{id}")]
        [HttpPost]
        public async Task<IActionResult> CreateFeatureByCarId(int id, int featureId)
        {
            var client = _httpClientFactory.CreateClient();

            var dto = new
            {
                CarID = id,
                FeatureID = featureId
            };
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:44308/api/CarFeatures", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { id = id });
            }

            TempData["Error"] = "Özellik atanamadı!";
            return RedirectToAction("CreateFeatureByCarId", new { id = id });
        }
    }
}