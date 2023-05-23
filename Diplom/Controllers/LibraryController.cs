using Microsoft.AspNetCore.Mvc;

namespace Diplom.Controllers
{
    public class LibraryController : Controller
    {
        public IActionResult Library()
        {
            return View();
        }
    }
}
