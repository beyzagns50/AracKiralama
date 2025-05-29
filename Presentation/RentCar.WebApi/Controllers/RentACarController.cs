using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCar.Domain.Entities;
using RentCar.Dto.AdminRentACar;
using RentCar.Persistence.Context;
using AutoMapper;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarController : ControllerBase
    {
        private readonly RentCarContext _context;
        private readonly IMapper _mapper;

        public RentACarController(RentCarContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminRentACarDto>>> GetAll()
        {
            var entities = await _context.RentACars
                .Include(x => x.Car)
                .Include(x => x.Location)
                .ToListAsync();

            var dtos = _mapper.Map<List<AdminRentACarDto>>(entities);
            return Ok(dtos);
        }

        [HttpPost]
        public async Task<ActionResult<AdminRentACarDto>> Create(AdminRentACarDto dto)
        {
            var entity = _mapper.Map<RentACar>(dto);
            _context.RentACars.Add(entity);
            await _context.SaveChangesAsync();

            var resultDto = _mapper.Map<AdminRentACarDto>(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.RentACarId }, resultDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdminRentACarDto>> GetById(int id)
        {
            var entity = await _context.RentACars
                .Include(x => x.Car)
                .Include(x => x.Location)
                .FirstOrDefaultAsync(x => x.RentACarId == id);

            if (entity == null)
                return NotFound();

            var dto = _mapper.Map<AdminRentACarDto>(entity);
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.RentACars.FindAsync(id);
            if (entity == null)
                return NotFound();

            _context.RentACars.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
