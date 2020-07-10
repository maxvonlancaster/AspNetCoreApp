using AspNetCoreApp.BLL.Interfaces;
using AspNetCoreApp.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreApp.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int presentationId) 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddQuestion([FromBody]Question question) 
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
