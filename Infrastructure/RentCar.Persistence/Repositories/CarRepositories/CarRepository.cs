using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentCar.Application.Interfaces.CarInterfaces;
using RentCar.Domain.Entities;
using RentCar.Persistence.Context;

namespace RentCar.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly RentCarContext _context;
        public CarRepository(RentCarContext context)
        {
            _context = context;
        }

        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }

        public List<Car> GetCarsListWithBrands()
        {
            var values = _context.Cars.Include(x => x.Brand).ToList();
            return values;
        }
        public List<Car> GetLast5CarsWithBrands()
        {
            return _context.Cars
                .Include(c => c.Brand)
                .Include(c => c.CarPricings) // CarPricing tablosunu dahil et
                .ThenInclude(cp => cp.Pricing) // Pricing bilgilerini de dahil et
                .OrderByDescending(c => c.CarID)
                .Take(5)
                .ToList();
        }

    }
}
