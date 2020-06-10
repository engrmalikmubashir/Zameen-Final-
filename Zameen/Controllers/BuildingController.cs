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
    public class BuildingController : Controller
    {

        private readonly ApplicationDbContext _db;

        private readonly IMapper _mapper;

        [BindProperty]
        public BuildingViewModel BuildingVm { get; set; }

        public BuildingController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            BuildingVm = new BuildingViewModel()
            {
                Countries = _db.Countries.ToList(),
                Cities = _db.Cities.ToList(),
                Building = new Models.Building()
            };
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var building = _db.Buildings
                .Include(m => m.Country)
                .Include(m => m.City);
            return View(building);
        }

        public IActionResult Create()
        {
            return View(BuildingVm);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(BuildingVm);
            }
            _db.Buildings.Add(BuildingVm.Building);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int id)
        {
            BuildingVm.Building = _db.Buildings.Include(m =>
                    m.Country)
                .Include(m => m.City)
                .SingleOrDefault(m => m.Id == id);
            if (BuildingVm.Building == null)
            {
                return NotFound();
            }

            return View(BuildingVm);
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost()
        {
            if (!ModelState.IsValid)
            {
                return View(BuildingVm);
            }
            _db.Update(BuildingVm.Building);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Building building = _db.Buildings.Find(id);
            if (building == null)
            {
                return NotFound();
            }
            _db.Buildings.Remove(building);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [AllowAnonymous]
        [HttpGet("api/floors/{buildingId}")]
        public IEnumerable<Floor> Floors(int buildingId)
        {
            return _db.Floors.ToList().Where(m => m.BuildingId == buildingId);
        }


        [AllowAnonymous]
        [HttpGet("api/floors/{buildingId}")]
        public IEnumerable<FloorResources> Floors()
        {
            var buildings = _db.Floors.ToList();

            return _mapper.Map<List<Floor>, List<FloorResources>>(buildings);

        }


    }

}
