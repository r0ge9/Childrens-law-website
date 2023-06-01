using Diplom.Domain;
using Diplom.Domain.Entities;
using Diplom.Models;
using Diplom.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;

namespace Diplom.Controllers
{
    public class AdminController : Controller
    {
        private readonly DataManager data;

        public AdminController(DataManager data)
        {
            this.data = data;
        }
        // GET: AdminController
        public ActionResult Admin()
        {
            return View(data);
        }

        public IActionResult News()
        {
            return View(data.Events.GetEvents());
        }
        public IActionResult EditEvent(int id)
        {
            var entity = id == default ? new Event() : data.Events.GetEventById(id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult EditEvent(Event model)
        {
            if (ModelState.IsValid)
            {

                data.Events.SaveEvent(model);
                return RedirectToAction(nameof(AdminController.News), nameof(AdminController).CutController());
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult DeleteEvent(int id)
        {
            data.Events.DeleteEvent(id);
            return RedirectToAction(nameof(AdminController.News), nameof(AdminController).CutController());
        }
        public IActionResult Tests()
        {
            return View(data.Tests.GetTests());
        }public IActionResult Reviews()
        {
            return View(data.Reviews.GetReviews());
        }
        [HttpPost]
        public IActionResult DeleteReview(int id)
        {
            data.Reviews.DeleteReview(id);
            return RedirectToAction(nameof(AdminController.Reviews), nameof(AdminController).CutController());
        }
        public IActionResult EditTest(int id)
        {
            var entity = id == default ? new Test() : data.Tests.GetTestById(id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult EditTest(Test model)
        {
            if (model.Description!=null||model.Name!=null)
            {
                data.Tests.SaveTest(model);
                return RedirectToAction(nameof(AdminController.Tests), nameof(AdminController).CutController());
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult DeleteTest(int id)
        {
            data.Tests.DeleteTest(id);
            return RedirectToAction(nameof(AdminController.Tests), nameof(AdminController).CutController());
        }
        public IActionResult EditQuestion(int id, int testId)
        {
            var entity = id == default ? new Question(testId) : data.Questions.GetQuestionById(id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult EditQuestion(Question model)
        {

            data.Questions.SaveQuestion(model);
            return RedirectToAction(nameof(AdminController.Tests), nameof(AdminController).CutController());


        }
        [HttpPost]
        public IActionResult DeleteQuestion(int id)
        {
            data.Questions.DeleteQuestion(id);
            return RedirectToAction(nameof(AdminController.Tests), nameof(AdminController).CutController());
        }
        public IActionResult Questions(int testId)
        {
            ViewBag.TestId = testId;
            return View(data.Questions.GetQuestionsByTestId(testId));
        }

    }
}
