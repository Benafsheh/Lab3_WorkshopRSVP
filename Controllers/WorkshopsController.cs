
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab3_WorkshopRSVP.Data;
using Lab3_WorkshopRSVP.Models;

namespace Lab3_WorkshopRSVP.Controllers
{
    public class WorkshopsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkshopsController(ApplicationDbContext context)
        {
            _context = context;
        }

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
        [ValidateAntiForgeryToken]
        public IActionResult Confirm(Rsvp model)
        {
            ViewData["Message"] =
                $"Thanks for registering, {model.FullName}!";

            return View(model);
        }

        public IActionResult Registrations()
        {
            var registrations = _context.Rsvps
                .AsNoTracking()
                .ToList();

            return View(registrations);
        }
    }
}
