using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zameen.Data;
using Zameen.Helpers;
using Zameen.Models;

namespace Zameen.Controllers
{
    [Authorize(Roles = Roles.Admin + "," + Roles.Executive)]
    public class CountryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CountryController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            return View(_db.Countries.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                _db.Countries.Add(country);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var country = _db.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }

            _db.Countries.Remove(country);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var country = _db.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        [HttpPost]
        public IActionResult Edit(Country country)
        {
            if (ModelState.IsValid)
            {
                _db.Countries.Update(country);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }


    }
}
