using Diplom.Domain;
using Diplom.Domain.Entities;
using Diplom.Service;
using Microsoft.AspNetCore.Mvc;
using NUglify.Helpers;
using System.Collections.Generic;

namespace Diplom.Controllers
{
    public class TestController : Controller
    {
        private readonly ILogger<TestController> _logger;
        private readonly DataManager dataManager;

        public TestController(ILogger<TestController> logger, DataManager dataManager)
        {
            _logger = logger;
            this.dataManager = dataManager;
            
        }
        public IActionResult Tests() => View(dataManager.Tests.GetTests());
        
        public IActionResult FirstQuestion(int id)
        {
            Extensions.answers = 0;
            Extensions.questions=new Queue<Question>(dataManager.Questions.GetQuestionsByTestId(id).ToList());
            return View(Extensions.questions.Dequeue());
        }
        [HttpPost]
        public IActionResult FirstQuestion(IFormCollection f)
        {
            string val = f["q"].ToString();
            if(val=="right")
            {
                Extensions.answers++;
            }
            return RedirectToAction("Questions");
        }
        public IActionResult Questions()
        {
            return Extensions.questions.Count!=0? View(Extensions.questions.Dequeue()):RedirectToAction("Results");
        }
        [HttpPost]
        public IActionResult Questions(IFormCollection f)
        {
            string val = f["q"].ToString();
            if (val == "right")
            {
                Extensions.answers++;
            }
            return Extensions.questions.Count != 0 ? View(Extensions.questions.Dequeue()) : RedirectToAction("Results");

        }
        public IActionResult Results()
        {
            return View();
        }
    }
}
