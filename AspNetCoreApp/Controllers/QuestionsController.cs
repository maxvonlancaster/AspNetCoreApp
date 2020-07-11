using AspNetCoreApp.BLL.Interfaces;
using AspNetCoreApp.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AspNetCoreApp.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IPresentationService _presentationService;

        public QuestionsController(IQuestionService questionService, IPresentationService presentationService)
        {
            _questionService = questionService;
            _presentationService = presentationService;
        }

        [HttpGet]
        public async Task<IActionResult> Index() 
        {
            var idString = (string)Url.ActionContext.RouteData.Values["id"];
            int id;
            Int32.TryParse(idString, out id);
            var presentation = await _presentationService.GetWithQuestions(id);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddQuestion([FromBody]Question question) 
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
