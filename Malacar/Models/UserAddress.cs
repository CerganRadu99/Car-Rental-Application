using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Malacar.Models
{
    public class UserAddress
    {
        public int UserAddressId { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; }
    }
}
