using Diplom.Domain;
using Diplom.Domain.Entities;
using Diplom.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;

namespace Diplom.Controllers
{
    public class AdminNewsController : Controller
    {
        private readonly DataManager data;
        public AdminNewsController(DataManager data) 
        {
            this.data = data;
        }
        public IActionResult AdminNews()
        {
            return View(data.Events.GetEvents());
        }
        public IActionResult Edit(int id)
        {
            var entity = id == default ? new Event() : data.Events.GetEventById(id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult Edit(Event model)
        {
            if (ModelState.IsValid)
            {
                data.Events.SaveEvent(model);
                return RedirectToAction(nameof(AdminController.Admin), nameof(AdminController).CutController());
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            data.Events.DeleteEvent(id);
            return RedirectToAction(nameof(AdminNewsController.AdminNews), nameof(AdminNewsController).CutController());
        }
    }
}
