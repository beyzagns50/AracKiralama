using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Dto.AdminRentACar
{
    public class AdminRentACarDto
    {
        public int LocationID { get; set; }
        public int CarID { get; set; }
        public bool Available { get; set; }

    }
}
