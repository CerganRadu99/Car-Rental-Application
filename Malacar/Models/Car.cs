using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Malacar.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        public string Plate { get; set; }

        public string Class { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public double Price { get; set; }

        public string Location { get; set; }

        public string Motorization { get; set; }

        public int Year { get; set; }

        public Boolean Availability { get; set; }

        public string DealsAppearance { get; set; }

        public string Color { get; set; }

        public int Seats { get; set; }

        public int Mileage { get; set; }

        public int RentedCounter { get; set; }

        public int DoorsNumber { get; set; }

        public double TimeBorrowed { get; set; }

        public ICollection<Rental> Rentals { get; set; }

        public ICollection<CarStation> CarStations { get; set; }
    }
}
