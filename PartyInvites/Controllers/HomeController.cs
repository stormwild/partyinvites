using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;
using PartyInvites.Services;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Party()
        {
            int hour = DateTime.UtcNow.Hour;
            ViewBag.Greeting = hour < 12 ? "Good morning" : "Good afternoon";
            return View();
        }

        [HttpGet]
        public IActionResult Rsvp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Rsvp(GuestResponse response)
        {
            if(ModelState.IsValid)
            {
                RsvpService.AddResponse(response);
                return View("Thanks", response);
            }
            return View();
        }

        public IActionResult Responses()
        {
            return View(RsvpService.Responses.Where(r => r.WillAttend == true));
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
