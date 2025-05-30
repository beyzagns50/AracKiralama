using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCar.Domain.Entities;
using RentCar.Persistence.Context;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarProcessController : ControllerBase
    {
        private readonly RentCarContext _context;

        public RentACarProcessController(RentCarContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentACarProcess>>> GetAll()
        {
            return await _context.RentACarProcesses
                .Include(x => x.Car)
                .Include(x => x.Customer)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RentACarProcess>> GetById(int id)
        {
            var entity = await _context.RentACarProcesses
                .Include(x => x.Car)
                .Include(x => x.Customer)
                .FirstOrDefaultAsync(x => x.RentACarProcessID == id);

            if (entity == null)
                return NotFound();

            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<RentACarProcess>> Create(RentACarProcess process)
        {
            _context.RentACarProcesses.Add(process);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = process.RentACarProcessID }, process);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.RentACarProcesses.FindAsync(id);
            if (entity == null)
                return NotFound();

            _context.RentACarProcesses.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
