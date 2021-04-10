using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Malacar.Models
{
    public class Station
    {
        public int StationId { get; set; }

        public string Name { get; set; }

        public int NumberOfVehicles { get; set; }

        public int NumberOfEmployees { get; set; }

        public ICollection<CarStation> CarStations { get; set; }

        public ICollection<StationAddress> StationAddresses { get; set; }
    }
}
