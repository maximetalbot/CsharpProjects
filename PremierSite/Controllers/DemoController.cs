using Microsoft.AspNetCore.Mvc;
using PremierSite.Models;

namespace PremierSite.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Message porté par le ViewBag !";
            TempData["Message"] = "Message porté par le TempData !";

            var vm = new MessageVM { Message="Message porté par le ViewModel !"};
            return View(vm);
        }
    }
}
