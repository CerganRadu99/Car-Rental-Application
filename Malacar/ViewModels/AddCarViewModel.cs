using Malacar.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Malacar.ViewModels
{
    public class AddCarViewModel
    {
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

        public IFormFile Photo { get; set; }

        public List<SelectListItem> StationItems { get
            {
                List<SelectListItem> listItems = new List<SelectListItem>();
                if(Stations != null)
                    listItems.AddRange(Stations.Select(Item => new SelectListItem { Value = Item.StationId + "", Text = Item.Name }));
                return listItems;
            } 
        }

        public ICollection<Station> Stations { get; set; }


        [Display(Name="Station")]
        public int SelectedStation { get; set; }
    }
}
