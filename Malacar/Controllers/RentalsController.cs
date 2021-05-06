using Malacar.Models;
using Malacar.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Malacar.Controllers
{
    public class RentalsController : Controller
    {
        private readonly RentalService _rentalService;
        public RentalsController(RentalService rentalService)
        {
            _rentalService = rentalService;
        }

        // GET: Rentals
        public IActionResult Index()
        {
            var rentals = _rentalService.GetRentals();
            return View(rentals);
        }

        // GET: Rentals/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = _rentalService.GetRentals().FirstOrDefault(m => m.RentalId == id);
            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // GET: Rentals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rentals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("RentalId,Description,StartDate,EndDate,PickUpLocation,DropOffLocation")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                _rentalService.AddRental(rental);
                _rentalService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(rental);
        }

        // GET: Rentals/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = _rentalService.GetRentals().FirstOrDefault(m => m.RentalId == id);
            if (rental == null)
            {
                return NotFound();
            }
            return View(rental);
        }

        // POST: Rentals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("RentalId,Description,StartDate,EndDate,PickUpLocation,DropOffLocation")] Rental rental)
        {
            if (id != rental.RentalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _rentalService.UpdateRental(rental);
                    _rentalService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalExists(rental.RentalId))
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
            return View(rental);
        }

        // GET: Rentals/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = _rentalService.GetRentals().FirstOrDefault(m => m.RentalId == id);
            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // POST: Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var rental = _rentalService.GetRentalsByCondition(b => b.RentalId == id).FirstOrDefault();
            _rentalService.DeleteRental(rental);
            _rentalService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalExists(int id)
        {
            return _rentalService.GetRentals().Any(e => e.RentalId == id);
        }
    }
}
