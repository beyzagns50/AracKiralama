using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentCar.Dto.CarDtos;
using RentCar.Dto.CarPricingDtos;
using RentCar.Domain.Entities; // Brand için

namespace RentCar.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int? brandId, string model, decimal? minPrice, decimal? maxPrice, string fuel, string transmission)
        {
            ViewBag.v1 = "Araçlarımız";
            ViewBag.v2 = "Aracınızı Seçiniz";
            var client = _httpClientFactory.CreateClient();

            // Markaları çek
            var brandResponse = await client.GetAsync("https://localhost:44308/api/Brands");
            List<Brand> brands = new();
            if (brandResponse.IsSuccessStatusCode)
            {
                var brandJson = await brandResponse.Content.ReadAsStringAsync();
                brands = JsonConvert.DeserializeObject<List<Brand>>(brandJson);
            }
            ViewBag.Brands = brands;

            // Araçları çek
            var responseMessage = await client.GetAsync("https://localhost:44308/api/CarPricings");
            List<ResultCarPricingWithCarDto> values = new();
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                values = JsonConvert.DeserializeObject<List<ResultCarPricingWithCarDto>>(jsonData);
            }

            // Filtre uygula
            if (brandId.HasValue)
                values = values.Where(x => x.BrandId == brandId.Value).ToList();

            if (!string.IsNullOrEmpty(model))
                values = values.Where(x => x.Model == model).ToList();

            if (minPrice.HasValue)
                values = values.Where(x => x.Amount >= minPrice.Value).ToList();

            if (maxPrice.HasValue)
                values = values.Where(x => x.Amount <= maxPrice.Value).ToList();

            if (!string.IsNullOrEmpty(fuel))
                values = values.Where(x => x.Fuel == fuel).ToList();

            if (!string.IsNullOrEmpty(transmission))
                values = values.Where(x => x.Transmission == transmission).ToList(); // <-- Vites filtresi

            // Seçili markaya göre modelleri bul
            List<string> models = new();
            if (brandId.HasValue)
                models = values.Select(x => x.Model).Distinct().ToList();
            else
                models = values.Select(x => x.Model).Distinct().ToList();

            // Yakıt ve vites tiplerini ViewBag'e ekle
            ViewBag.Fuels = values.Select(x => x.Fuel).Distinct().ToList();
            ViewBag.Transmissions = values.Select(x => x.Transmission).Distinct().ToList(); // <-- Eklendi
            ViewBag.SelectedBrand = brandId;
            ViewBag.SelectedModel = model;
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;
            ViewBag.SelectedFuel = fuel;
            ViewBag.SelectedTransmission = transmission; // <-- Eklendi

            return View(values);
        }

        public async Task<IActionResult> CarDetail(int id)
        {
            ViewBag.v1 = "Araç Detayları";
            ViewBag.v2 = "Aracın Teknik Aksesuar ve Özellikleri";
            ViewBag.carid = id;
            return View();
        }
    }
}