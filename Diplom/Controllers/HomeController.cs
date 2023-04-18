using Diplom.Domain;
using Diplom.Domain.Entities;
using Diplom.Models;
using Diplom.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Localization;

namespace Diplom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataManager dataManager;
        private readonly IHtmlLocalizer<HomeController> localizer;

        public string CurrentLangCode {  get; protected set; }
        public HomeController(ILogger<HomeController> logger,DataManager dataManager, IHtmlLocalizer<HomeController> localizer)
        {
            _logger = logger;
            this.dataManager = dataManager;
            this.localizer=localizer;
        }

        
        public IActionResult Index()
        {
            return View(dataManager.Events.GetEvents());
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact() 
        {
            return View();
        }
        public IActionResult News()
        {
            return View(dataManager.Events.GetEvents());
        }
        [HttpGet]
		public IActionResult Reviews()
		{
            ViewBag.Review = new Review();
			return View(dataManager.Reviews.GetReviews());
		}
		
		[HttpGet]
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
		public IActionResult Event(int id)
        {
            return View("Event",dataManager.Events.GetEventById(id));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}