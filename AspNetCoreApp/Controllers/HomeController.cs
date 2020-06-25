﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreApp.Controllers
{
    public class HomeController : Controller 
    {
        [Authorize]
        public IActionResult Index() 
        {
            return View();
        }

        public IActionResult Streaming() 
        {
            return View();
        }
    }
}
