using Diplom.Domain;
using Diplom.Domain.Entities;
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

		public IActionResult Edit()
		{
			return RedirectToAction(nameof(AdminNewsController.AdminNews), nameof(AdminNewsController).CutController());
		}
		
		public IActionResult Create(int id)
		{
            var entity = id == default ? new Event() : data.Events.GetEventById(id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult Create(Event model)
        {
            //if (ModelState.IsValid)
            //{
                data.Events.SaveEvent(model);
                return RedirectToAction(nameof(AdminController.Admin), nameof(AdminController).CutController());
           // }
            //return View(model);
        }

    }
}
