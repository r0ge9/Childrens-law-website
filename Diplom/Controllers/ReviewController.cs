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
			ViewBag.Review = new Review();
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
				dataManager.Reviews.SaveReview(model);
				return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
			}
			return View(model);
		}
	}
}
