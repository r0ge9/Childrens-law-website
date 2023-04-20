using Diplom.Domain;
using Diplom.Domain.Entities;
using Diplom.Models;
using Diplom.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Localization;

namespace Diplom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataManager dataManager;


        public string CurrentLangCode {  get; protected set; }
        public HomeController(ILogger<HomeController> logger,DataManager dataManager)
        {
            _logger = logger;
            this.dataManager = dataManager;

        }

        
        public IActionResult Index()
        {
            return View(dataManager.Events.GetEvents());
        }
		[HttpPost]
		public IActionResult SetLanguage(string culture, string returnUrl)
		{
			Response.Cookies.Append(
				CookieRequestCultureProvider.DefaultCookieName,
				CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
				new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
			);

			return LocalRedirect(returnUrl);
		}
		public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact() 
        {
            return View();
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