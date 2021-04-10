using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Malacar.Models
{
    public class Address
    {
        public int AddressId { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string County { get; set; }

        public string Zip { get; set; }

        public ICollection<StationAddress> StationAddresses { get; set; }

        public ICollection<AdminAddress> AdminAddresses { get; set; }

        public ICollection<UserAddress> UserAddresses { get; set; }
    }
}
