using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Malacar.Models
{
    public class CarStation
    {
        [Key]
        public int CarStationId { get; set; }

        public int StationaryTime { get; set; }

        public int CarID { get; set; }

        public Car Car { get; set; }

        public int StationId { get; set; }

        public Station Station { get; set; }
    }
}
