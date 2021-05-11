using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Malacar.Models;
using Malacar.ViewModels;
using Malacar.Services;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Malacar.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarService _carService;
        private readonly StationService _stationService;
        private readonly CarStationService _carStationService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public CarsController(CarService CarService, StationService StationService, CarStationService CarStationService, IHostingEnvironment hostingEnvironment)
        {
            _carService = CarService;
            _stationService = StationService;
            _carStationService = CarStationService;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Cars
        public IActionResult Index()
        {
            var cars = _carService.GetCars();
            return View(cars);
        }

        // GET: Cars/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = _carService.GetCars().FirstOrDefault(m => m.CarId == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            var addModel = new AddCarViewModel
            {
                Stations = _stationService.GetStations().ToList<Station>()
            };
            return View(addModel);
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] AddCarViewModel car)
        {
            
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if(car.Photo != null)
                {
                   string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                   uniqueFileName =  Guid.NewGuid().ToString() + "_" + car.Photo.FileName;
                   string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    car.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    
                }
                Car newCar = new Car
                {
                    Plate = car.Plate,
                    Model = car.Model,
                    Price = car.Price,
                    Location = car.Location,
                    Motorization = car.Motorization,
                    Year = car.Year,
                    Availability = car.Availability,
                    DealsAppearance = car.DealsAppearance,
                    Color = car.Color,
                    Seats = car.Seats,
                    Mileage = car.Mileage,
                    RentedCounter = car.RentedCounter,
                    DoorsNumber = car.DoorsNumber,
                    TimeBorrowed = car.TimeBorrowed,
                    Brand = car.Brand,
                    Class = car.Class,
                    Rentals = new List<Rental>(),
                    CarStations = new List<CarStation>(),
                    ImagePath = uniqueFileName
                };
                Station selectedStation = _stationService.GetStations().SingleOrDefault(station => station.StationId == car.SelectedStation);
                _carService.AddCar(newCar);
                _carService.Save();
                var myCar = _carService.GetCars().LastOrDefault();
                if (myCar != null)
                {
                    _carStationService.AddCarStation(new CarStation
                    {
                        CarID = myCar.CarId,
                        StationId = selectedStation.StationId,
                        StationaryTime = 0
                    });
                    _carStationService.Save();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = _carService.GetCars().FirstOrDefault(m => m.CarId == id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CarId,Plate,Class,Brand,Model,Price,Location,Motorization,Year,Availability,DealsAppearance,Color,Seats,Mileage,RentedCounter,DoorsNumber,TimeBorrowed, ImagePath")] Car car)
        {
            if (id != car.CarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _carService.UpdateCar(car);
                    _carService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.CarId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = _carService.GetCars().FirstOrDefault(m => m.CarId == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var car = _carService.GetCarsByCondition(b => b.CarId == id).FirstOrDefault();
            _carService.DeleteCar(car);
            _carService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _carService.GetCars().Any(e => e.CarId == id);
        }
    }
}

