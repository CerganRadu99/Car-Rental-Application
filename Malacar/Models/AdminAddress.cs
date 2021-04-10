using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Malacar.Models
{
    public class AdminAddress
    {
        public int AdminAddressId { get; set; }

        public int AdminId { get; set; }

        public Admin Admin { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; }
    }
}
