using AspNetCoreApp.BLL.Const;
using AspNetCoreApp.BLL.Interfaces;
using AspNetCoreApp.DAL.Entities;
using AspNetCoreApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreApp.Controllers
{
    public class PresentationController : Controller
    {
        private readonly IPresentationService _presentationService;
        private readonly IUserService _userService;

        public PresentationController(IPresentationService presentationService, IUserService userService)
        {
            _presentationService = presentationService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPresentation(FileUpload formFile) 
        {
            if (formFile != null) 
            {
                var user = await _userService.GetByUserName(User.Identity.Name);
                byte[] fileData = null;
                using (var binaryReader = new BinaryReader(formFile.File.OpenReadStream())) 
                {
                    fileData = binaryReader.ReadBytes((int)formFile.File.Length);
                };
                Presentation presentation = new Presentation()
                {
                    User = user,
                    File = fileData,
                    Name = formFile.File.FileName
                };
                await _presentationService.Create(presentation);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Route("getPresentations")]
        public async Task<IActionResult> GetPresentations([FromBody]PresentationListing presentationListing) 
        {
            return Json(await _presentationService.GetList(presentationListing.Take, presentationListing.Skip, User.Identity.Name));
        }
    }
}
