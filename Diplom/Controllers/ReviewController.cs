using Diplom.Domain.Entities;
using Diplom.Domain;
using Diplom.Service;
using Microsoft.AspNetCore.Mvc;

namespace Diplom.Controllers
{
	public class ReviewController : Controller
	{
		private readonly DataManager dataManager;
		private readonly ILogger<ReviewController> _logger;
		public ReviewController(ILogger<ReviewController> logger,DataManager dataManager)
		{
			_logger = logger;
			this.dataManager = dataManager;
		}
		
		public IActionResult Reviews()
		{
			return View(dataManager.Reviews.GetReviews());
		}

		
		public IActionResult AddReview()
		{
			ViewBag.Review = new Review();
			return View();
		}
		[HttpPost]
		public IActionResult AddReview(Review model)
		{


			if (ModelState.IsValid)
			{
                if (model.Image.Length <= 20)
                    model.Image = "https://upload.wikimedia.org/wikipedia/commons/3/3d/%D0%9D%D0%B5%D1%82_%D0%B8%D0%B7%D0%BE%D0%B1%D1%80%D0%B0%D0%B6%D0%B5%D0%BD%D0%B8%D1%8F.jpg";
                dataManager.Reviews.SaveReview(model);
				return RedirectToAction(nameof(ReviewController.Reviews), nameof(ReviewController).CutController());
			}
			return View(model);
		}
	}
}
