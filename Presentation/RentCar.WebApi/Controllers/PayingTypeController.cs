using Microsoft.AspNetCore.Mvc;
using RentCar.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RentCar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayingTypeController : ControllerBase
    {
        private static List<PayingType> _payingTypes = new List<PayingType>
        {
            new PayingType { ID = 1, Name = "Kredi Kartı", Description = "Ödeme kredi kartı ile yapılır" },
            new PayingType { ID = 2, Name = "Nakit", Description = "Ödeme nakit olarak yapılır" }
        };

        // GET: api/PayingType
        [HttpGet]
        public ActionResult<IEnumerable<PayingType>> GetAll()
        {
            return Ok(_payingTypes);
        }

        // GET: api/PayingType/{id}
        [HttpGet("{id}")]
        public ActionResult<PayingType> GetById(int id)
        {
            var payingType = _payingTypes.FirstOrDefault(p => p.ID == id);
            if (payingType == null)
                return NotFound("Ödeme türü bulunamadı.");

            return Ok(payingType);
        }

        // POST: api/PayingType
        [HttpPost]
        public ActionResult Create([FromBody] PayingType newPayingType)
        {
            if (newPayingType == null)
                return BadRequest("Geçersiz veri.");

            newPayingType.ID = _payingTypes.Count + 1;
            _payingTypes.Add(newPayingType);

            return CreatedAtAction(nameof(GetById), new { id = newPayingType.ID }, newPayingType);
        }

        // PUT: api/PayingType/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] PayingType updatedPayingType)
        {
            var payingType = _payingTypes.FirstOrDefault(p => p.ID == id);
            if (payingType == null)
                return NotFound("Güncellenecek ödeme türü bulunamadı.");

            payingType.Name = updatedPayingType.Name;
            payingType.Description = updatedPayingType.Description;

            return NoContent();
        }

        // DELETE: api/PayingType/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var payingType = _payingTypes.FirstOrDefault(p => p.ID == id);
            if (payingType == null)
                return NotFound("Silinecek ödeme türü bulunamadı.");

            _payingTypes.Remove(payingType);
            return NoContent();
        }
    }
}
