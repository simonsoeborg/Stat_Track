﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StatTrack.Controllers
{
    public class TeamController : Controller
    {

        
        public IActionResult Index()
        {

            return View();
        }
    }
}
