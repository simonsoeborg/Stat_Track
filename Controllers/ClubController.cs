using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Logic;
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
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}
