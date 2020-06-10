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
    public class FloorController : Controller
    {

        private readonly ApplicationDbContext _db;

        private readonly IMapper _mapper;

        [BindProperty]
        public FloorViewModel FloorVm { get; set; }

        public FloorController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            FloorVm = new FloorViewModel()
            {
                Buildings = _db.Buildings.ToList(),
                Floor = new Models.Floor()
            };
        }

        public IActionResult Index()
        {
            var floor = _db.Floors
                .Include(m => m.Building);
            return View(floor);
        }

        public IActionResult Create()
        {
            return View(FloorVm);
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(FloorVm);
            }
            _db.Floors.Add(FloorVm.Floor);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int id)
        {
            FloorVm.Floor = _db.Floors.Include(m
                    => m.Building)
                .SingleOrDefault(m => m.Id == id);
            if (FloorVm.Floor == null)
            {
                return NotFound();
            }

            return View(FloorVm);
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost()
        {
            if (!ModelState.IsValid)
            {
                return View(FloorVm);
            }
            _db.Update(FloorVm.Floor);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Floor floor = _db.Floors.Find(id);
            if (floor == null)
            {
                return NotFound();
            }
            _db.Floors.Remove(floor);
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
        [HttpGet("api/floors")]
        public IEnumerable<FloorResources> Floors()
        {
            var floors = _db.Floors.ToList();

            return _mapper.Map<List<Floor>, List<FloorResources>>(floors);

        }



        //[AllowAnonymous]
        //[HttpGet("api/floors/{buildingId}")]
        //public IEnumerable<Floor> Floors(int buildingId)
        //{
        //    return _db.Floors.ToList().Where(m => m.BuildingId == buildingId);
        //}

        //[AllowAnonymous]
        //[HttpGet("api/floors")]
        //public IEnumerable<FloorResources> Floors()
        //{
        //    var floors = _db.Floors.ToList();

        //    return _mapper.Map<List<Floor>, List<FloorResources>>(floors);

        //}


    }

}
