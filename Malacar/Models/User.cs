using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Malacar.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public int RentedCars { get; set; }

        public int PenalizationPoints { get; set; }

        public string PhoneNumber { get; set; }

        public Boolean IsAdmin { get; set; }

        public string DrivingLicenceNo { get; set; }

        public ICollection<Rental> Rentals { get; set; }

        public ICollection<Payment> Payments { get; set; }

        public ICollection<UserAddress> UserAddresses { get; set; }
    }
}
