using Diplom.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Diplom.Controllers
{
	public class NewsController : Controller
	{
		private readonly ILogger<NewsController> _logger;
		private DataManager dataManager;
		public NewsController(ILogger<NewsController> logger, DataManager dataManager)
		{
			_logger = logger;
			this.dataManager = dataManager;

		}
		public IActionResult News()
		{
			var items = dataManager.Events.GetEvents().ToList();
			items = items.OrderBy(x => x.Date).Reverse().ToList();
            return View(items);
		}
	}
}
