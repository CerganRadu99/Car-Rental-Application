using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Malacar.Models
{
    public class Rental
    {
        public int RentalId { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string PickUpLocation { get; set; }

        public string DropOffLocation { get; set; }

        public Car Car { get; set; }

        public User User { get; set; }
    }
}
