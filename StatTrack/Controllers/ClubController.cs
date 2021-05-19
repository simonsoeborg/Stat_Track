using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Logic;
using StatTrack.Data;
using static DataLibrary.Logic.ClubProcessor;
using StatTrack.Models;

namespace StatTrack.Controllers
{
    public class ClubController : Controller
    {
        public IActionResult Index()
        {
            var data = LoadClubs();
            List<ClubModel> clubs = new List<ClubModel>();

            foreach (var item in data)
            {
                clubs.Add(new ClubModel()
                {
                    Id = item.Id,
                    Initials = item.Initials,
                    Name = item.Name,
                    Address = item.Address,
                    Postal = item.Postal,
                    City = item.City
                });
            }
            return View(clubs);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClubModel model)
        {
            if (ModelState.IsValid)
            {
                CreateClub(model.Initials,model.Name, model.Address, model.Postal, model.City);

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int clubId, string clubInitials, string clubName, string clubCity, int clubPostal, string clubAddress)
        {
            var model = new ClubModel { Id = clubId, Initials = clubInitials, Name = clubName, City = clubCity, Postal = clubPostal, Address = clubAddress};

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id)
        {
            if (ModelState.IsValid)
            {
                DeleteClub(Id);
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Edit(int clubId, string clubInitials, string clubName, string clubCity, int clubPostal, string clubAddress)
        {
            var model = new ClubModel { Id = clubId, Initials = clubInitials, Name = clubName, City = clubCity, Postal = clubPostal, Address = clubAddress };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ClubModel model)
        {
            if (ModelState.IsValid)
            {
                UpdateClub(model.Id,model.Initials,model.Name,model.City,model.Postal,model.Address);
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Details(int clubId, string clubInitials, string clubName, string clubCity, int clubPostal, string clubAddress)
        {
            var model = new ClubModel { Id = clubId, Initials = clubInitials, Name = clubName, City = clubCity, Postal = clubPostal, Address = clubAddress};

            return View(model);
        }
    }
}
