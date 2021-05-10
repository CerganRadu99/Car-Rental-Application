using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Malacar.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public int RentedCars { get; set; }

        public int PenalizationPoints { get; set; }

        [Required]
        public string DrivingLicenceNo { get; set; }

        public ICollection<Rental> Rentals { get; set; }

        public ICollection<Payment> Payments { get; set; }

        public ICollection<UserAddress> UserAddresses { get; set; }
    }
}
