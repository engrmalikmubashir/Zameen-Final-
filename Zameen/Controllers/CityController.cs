using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zameen.Controllers.Resources;
using Zameen.Data;
using Zameen.Helpers;
using Zameen.Models;
using Zameen.Models.ViewModels;

namespace Zameen.Controllers
{
    [Authorize(Roles = Roles.Admin + "," + Roles.Executive)]
    public class CityController : Controller
    {

        private readonly ApplicationDbContext _db;

        private readonly IMapper _mapper;

        [BindProperty]
        public CityViewModel CityVm { get; set; }

        public CityController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            CityVm = new CityViewModel()
            {
                Countries = _db.Countries.ToList(),
                City = new Models.City()
            };
        }

        public IActionResult Index()
        {
            var city = _db.Cities.Include(m => m.Country);
            return View(city);
        }

        public IActionResult Create()
        {
            return View(CityVm);
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(CityVm);
            }
            _db.Cities.Add(CityVm.City);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int id)
        {
            CityVm.City = _db.Cities.Include(m => m.Country)
                .SingleOrDefault(m => m.Id == id);
            if (CityVm.City == null)
            {
                return NotFound();
            }

            return View(CityVm);
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost()
        {
            if (!ModelState.IsValid)
            {
                return View(CityVm);
            }
            _db.Update(CityVm.City);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            City city = _db.Cities.Find(id);
            if (city == null)
            {
                return NotFound();
            }
            _db.Cities.Remove(city);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [AllowAnonymous]
        [HttpGet("api/cities/{countryId}")]
        public IEnumerable<City> Cities(int countryId)
        {
            return _db.Cities.ToList().Where(m => m.CountryId == countryId);
        }


        [AllowAnonymous]
        [HttpGet("api/cities")]
        public IEnumerable<CityResources> Cities()
        {
            var bmodels = _db.Cities.ToList();

            return _mapper.Map<List<City>, List<CityResources>>(bmodels);

        }


    }

}
