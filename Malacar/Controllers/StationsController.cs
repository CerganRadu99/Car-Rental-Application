using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Malacar.Models;
using Malacar.Services;

namespace Malacar.Controllers
{
    public class StationsController : Controller
    {
        private readonly StationService _stationService;

        public StationsController(StationService stationService)
        {
            _stationService = stationService;
        }

        // GET: Stations
        public IActionResult Index()
        {
            var stations = _stationService.GetStations();
            return View(stations);
        }

        // GET: Stations/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var station = _stationService.GetStations().FirstOrDefault(m => m.StationId == id);
            if (station == null)
            {
                return NotFound();
            }

            return View(station);
        }

        // GET: Stations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("StationId,Name,NumberOfVehicles,NumberOfEmployees")] Station station)
        {
            if (ModelState.IsValid)
            {
                _stationService.AddStation(station);
                _stationService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(station);
        }

        // GET: Stations/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var station = _stationService.GetStations().FirstOrDefault(m => m.StationId == id);
            if (station == null)
            {
                return NotFound();
            }
            return View(station);
        }

        // POST: Stations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("StationId,Name,NumberOfVehicles,NumberOfEmployees")] Station station)
        {
            if (id != station.StationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _stationService.UpdateStation(station);
                    _stationService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StationExists(station.StationId))
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
            return View(station);
        }

        // GET: Stations/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var station = _stationService.GetStations().FirstOrDefault(m => m.StationId == id);
            if (station == null)
            {
                return NotFound();
            }

            return View(station);
        }

        // POST: Stations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var station = _stationService.GetStationsByCondition(b => b.StationId == id).FirstOrDefault();
            _stationService.DeleteStation(station);
            _stationService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool StationExists(int id)
        {
            return _stationService.GetStations().Any(e => e.StationId == id);
        }
    }
}
