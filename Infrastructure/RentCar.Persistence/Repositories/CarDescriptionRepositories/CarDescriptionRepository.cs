using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentCar.Application.Interfaces.CarDescriptionInterfaces;
using RentCar.Domain.Entities;
using RentCar.Persistence.Context;

namespace RentCar.Persistence.Repositories.CarDescriptionRepositories
{
    public class CarDescriptionRepository : ICarDescriptionRepository
    {
        private readonly RentCarContext _context;

        public CarDescriptionRepository(RentCarContext context)
        {
            _context = context;
        }

		async Task<CarDescription> ICarDescriptionRepository.GetCarDescription(int carId)
		{
			var values =await _context.CarDescriptions.Where(x => x.CarID == carId).FirstOrDefaultAsync();
			return values;
		}
	}
}
