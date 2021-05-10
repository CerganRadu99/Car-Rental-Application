using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Malacar.Models;
using Malacar.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Malacar.Controllers
{
    [Authorize(Roles = "Administrator,User")]
    public class CarsController : Controller
    {
        private readonly CarContext _context;

        public CarsController(CarContext context)
        {
            _context = context;
        }

        // GET: Cars
        [Authorize(Roles = "Administrator,User")]
        public async Task<IActionResult> Index(string sortOrder, string searchString, int priceSearch)
        {
            ViewData["BrandSortParm"] = String.IsNullOrEmpty(sortOrder) ? "brand_desc" : "";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";

            var cars = from s in _context.Cars
                       select s;

            if(!String.IsNullOrEmpty(searchString))
            {
                cars = cars.Where(s => s.Brand.Contains(searchString)
                || s.Plate.Contains(searchString)|| s.Motorization.Contains(searchString)||s.Model.Contains(searchString)||s.Color.Contains(searchString));
            }

            switch(sortOrder)
            {
                case "brand_desc":
                    cars = cars.OrderByDescending(s => s.Brand);
                    break;
                case "Price":
                    cars = cars.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    cars = cars.OrderByDescending(s => s.Price);
                    break;
                default:
                    cars = cars.OrderBy(s => s.Brand);
                    break;
            }
            return View(await cars.AsNoTracking().ToListAsync());
        }

        // GET: Cars/Details/5
        [Authorize(Roles = "Administrator,User")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .FirstOrDefaultAsync(m => m.CarId == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            var addModel = new AddCarViewModel {
                Stations = _context.Stations.ToList<Station>()
            };
            return View(addModel);
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] AddCarViewModel car)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(car);
                Car newCar = new Car
                {
                    Brand = car.Brand,
                    Class = car.Class,
                    Rentals = new List<Rental>(),
                    CarStations = new List<CarStation>()
                };
                Station selectedStation = _context.Stations.SingleOrDefault(station => station.StationId == car.SelectedStation);
                CarStation newCarStation = new CarStation
                {
                    Car = newCar,
                    Station = selectedStation
                };
                newCar.CarStations.Add(newCarStation);
                _context.Add(newCar);
                //_context.Add(newCarStation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("CarId,Plate,Class,Brand,Model,Price,Location,Motorization,Year,Availability,DealsAppearance,Color,Seats,Mileage,RentedCounter,DoorsNumber,TimeBorrowed")] Car car)
        {
            if (id != car.CarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
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
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .FirstOrDefaultAsync(m => m.CarId == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.CarId == id);
        }
    }
}
