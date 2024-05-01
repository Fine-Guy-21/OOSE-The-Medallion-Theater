using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using The_Medallion_Theater.Models;

namespace The_Medallion_Theater.Controllers
{
    public class TheaterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult BookNow()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BookNow(Ticket ticket)
        {
            return View();
        }
    }
}
