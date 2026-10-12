
using Microsoft.AspNetCore.Mvc;
using Lab3_WorkshopRSVP.Models;

namespace Lab3_WorkshopRSVP.Controllers
{
    public class WorkshopsController : Controller
    {
        private static List<Rsvp> registrations = new List<Rsvp>();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Confirm(Rsvp model)
        {
            registrations.Add(model);

            ViewData["Message"] =
                $"Thanks for registering, {model.FullName}!";

            return View(model);
        }

        public IActionResult Registrations()
        {
            return View(registrations);
        }
    }
}
