using AspNetCoreApp.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreApp.Controllers
{
    public class PresentationController : Controller
    {
        private readonly IPresentationService _presentationService;

        public PresentationController(IPresentationService presentationService)
        {
            _presentationService = presentationService;
        }
    }
}
