using Malacar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Malacar.ViewModels
{
    public class AddRentalViewModel
    {
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string PickUpLocation { get; set; }

        public string DropOffLocation { get; set; }

        public Car Car { get; set; }

        public AppUser User { get; set; }

        public string UserId { get; set; }
    }
}
