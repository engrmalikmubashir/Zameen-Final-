using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zameen.Data;
using Zameen.Models;
using Zameen.Models.ViewModels;

namespace Zameen.Controllers
{
    public class ClientController : Controller
    {

        private readonly ApplicationDbContext _db;

        [BindProperty]
        public ClientViewModel ClientVm { get; set; }

        public ClientController(ApplicationDbContext db)
        {
            _db = db;
            ClientVm = new ClientViewModel()
            {
                Countries = _db.Countries.ToList(),
                Cities = _db.Cities.ToList(),
                Client = new Models.Client()
            };
        }

        public IActionResult Index()
        {
            var client = _db.Clients
                .Include(m => m.Country)
                .Include(m => m.City);
            return View(client);
        }

        public IActionResult Create()
        {
            return View(ClientVm);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(ClientVm);
            }
            _db.Clients.Add(ClientVm.Client);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int id)
        {
            ClientVm.Client = _db.Clients.Include(m =>
                    m.Country)
                .Include(m => m.City)
                .SingleOrDefault(m => m.Id == id);
            if (ClientVm.Client == null)
            {
                return NotFound();
            }

            return View(ClientVm);
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost()
        {
            if (!ModelState.IsValid)
            {
                return View(ClientVm);
            }
            _db.Update(ClientVm.Client);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Client Client = _db.Clients.Find(id);
            if (Client == null)
            {
                return NotFound();
            }
            _db.Clients.Remove(Client);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
