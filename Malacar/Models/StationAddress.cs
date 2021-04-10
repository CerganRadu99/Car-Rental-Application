using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Malacar.Models
{
    public class StationAddress
    {
        public int StationAddressId { get; set; }

        public int StationId { get; set; }
        
        public Station Station { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; }

    }
}
