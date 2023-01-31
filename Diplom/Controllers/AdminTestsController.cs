using Diplom.Domain.Entities;
using Diplom.Domain;
using Diplom.Service;
using Microsoft.AspNetCore.Mvc;

namespace Diplom.Controllers
{
    public class AdminTestsController : Controller
    {
        private readonly DataManager data;
        public AdminTestsController(DataManager data)
        {
            this.data = data;
        }
        public IActionResult AdminTests()
        {
            return View(data.Tests.GetTests());
        }
        public IActionResult EditTest(int id)
        {
            var entity = id == default ? new Test() : data.Tests.GetTestById(id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult EditTest(Test model)
        {
            if (ModelState.IsValid)
            {
                data.Tests.SaveTest(model);
                return RedirectToAction(nameof(AdminController.Admin), nameof(AdminController).CutController());
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult DeleteTest(int id)
        {
            data.Tests.DeleteTest(id);
            return RedirectToAction(nameof(AdminTestsController.AdminTests), nameof(AdminTestsController).CutController());
        }
		public IActionResult EditQuestion(int id)
		{
			var entity = id == default ? new Question() : data.Questions.GetQuestionById(id);
			return View(entity);
		}
		[HttpPost]
		public IActionResult EditQuestion(Question model)
		{
			if (ModelState.IsValid)
			{
				data.Questions.SaveQuestion(model);
				return RedirectToAction(nameof(AdminController.Admin), nameof(AdminController).CutController());
			}
			return View(model);
		}
		[HttpPost]
		public IActionResult DeleteQuestion(int id)
		{
			data.Questions.DeleteQuestion(id);
			return RedirectToAction(nameof(AdminTestsController.AdminTests), nameof(AdminTestsController).CutController());
		}
	}
}
