using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zameen.Data;
using Zameen.Helpers;
using Zameen.Models;
using Zameen.Models.ViewModels;

namespace Zameen.Controllers
{

    [Authorize(Roles = Roles.Admin + "," + Roles.Executive)]
    public class ShopController : Controller
    {

        private readonly ApplicationDbContext _db;

        [BindProperty]
        public ShopViewModel ShopVm { get; set; }

        public ShopController(ApplicationDbContext db)
        {
            _db = db;
            ShopVm = new ShopViewModel()
            {
                Buildings = _db.Buildings.ToList(),
                Floors = _db.Floors.ToList(),
                Shop = new Models.Shop()
            };
        }

        public IActionResult Index()
        {
            var shop = _db.Shops
                .Include(m => m.Building)
                .Include(m => m.Floor);
            return View(shop);
        }

        public IActionResult Create()
        {
            return View(ShopVm);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(ShopVm);
            }
            _db.Shops.Add(ShopVm.Shop);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int id)
        {
            ShopVm.Shop = _db.Shops.Include(m =>
                    m.Building)
                .Include(m => m.Floor)
                .SingleOrDefault(m => m.Id == id);
            if (ShopVm.Shop == null)
            {
                return NotFound();
            }

            return View(ShopVm);
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost()
        {
            if (!ModelState.IsValid)
            {
                return View(ShopVm);
            }
            _db.Update(ShopVm.Shop);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Shop shop = _db.Shops.Find(id);
            if (shop == null)
            {
                return NotFound();
            }
            _db.Shops.Remove(shop);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }

}
