using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentCar.Application.Features.CQRS.Results.CarResults;
using RentCar.Application.Interfaces;
using RentCar.Application.Interfaces.CarInterfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLast5CarsWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetLast5CarsWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public List<GetCarWithBrandQueryResult> Handle()
        {
            var cars = _repository.GetLast5CarsWithBrands();

            return cars.Select(car =>
            {
                // Fiyat bilgilerini al
                var dailyAmount = car.CarPricings.FirstOrDefault(p => p.Pricing.Name == "Gunluk")?.Amount;
                var weeklyAmount = car.CarPricings.FirstOrDefault(p => p.Pricing.Name == "Haftalik")?.Amount;
                var monthlyAmount = car.CarPricings.FirstOrDefault(p => p.Pricing.Name == "Aylik")?.Amount;


                return new GetCarWithBrandQueryResult
                {
                    CarID = car.CarID,
                    BrandID = car.BrandID,
                    BrandName = car.Brand.Name,
                    Model = car.Model,
                    CoverImageUrl = car.CoverImageUrl,
                    Km = car.Km,
                    Transmission = car.Transmission,
                    Seat = car.Seat,
                    Luggage = car.Luggage,
                    Fuel = car.Fuel,
                    BigImageUrl = car.BigImageUrl,
                    DailyAmount = dailyAmount,
                    WeeklyAmount = weeklyAmount,
                    MonthlyAmount = monthlyAmount
                };
            }).ToList();
        }

    }
}
