using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using The_Medallion_Theater.Models;

namespace The_Medallion_Theater.Controllers
{
    public class TheaterController : Controller
    {
        private readonly IManageRepository ManageRepository;
        private readonly UserManager<Patron> userManager;

        public TheaterController(IManageRepository _ManageRepository, UserManager<Patron> _userManager)
        {
            ManageRepository = _ManageRepository;
            userManager = _userManager;
        }

        public IActionResult BrowsePerformance()
        {
            return View(ManageRepository.GetPerformances());
        }
        public IActionResult aBrowsePerformance()
        {
            return View(ManageRepository.GetPerformances());
        }

        public IActionResult BrowseProduction()
        {
            
            return View(ManageRepository.GetProductions());
        }

/*add production*/
        
        [HttpGet]
        public IActionResult Addproduction()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Addproduction(Production pr)
        {
            pr.ProductionId = Guid.NewGuid().ToString("N");
            if (ModelState.IsValid)
            {
                ManageRepository.SaveProduction(pr);
                return RedirectToAction("BrowseProduction");
            }
            return View(pr);
        }

/*edit production*/

        [HttpGet]
        public IActionResult Editproduction(string id)
        {
            Production pr = ManageRepository.GetProductionByID(id);
            ProductionVm pvm = new ProductionVm()
            {
                ProductionId = id,
                ProductionName = pr.ProductionName,
                ProductionType = pr.ProductionType
            };
            return View(pvm);
        }
        [HttpPost]
        public IActionResult Editproduction(ProductionVm pvm)
        {
            if (ModelState.IsValid)
            {
                Production pr = new Production()
                {
                    ProductionId = pvm.ProductionId,
                    ProductionName = pvm.ProductionName,
                    ProductionType = pvm.ProductionType
                };
                ManageRepository.UpdateProduction(pr);
                return RedirectToAction("BrowseProduction");
            }
            return View(pvm);
        }
/* Delete Productions */

        
        public IActionResult DeleteProduction(string id)
        {

            Production production = ManageRepository.GetProductionByID(id);
            if (production != null) { 
            ManageRepository.DeleteProdution(production);
            }

            return RedirectToAction("BrowseProduction");

        }

/*Add Performance*/

        [HttpGet]
        public IActionResult AddPerformance()
        {
            List<Production> prs = ManageRepository.GetProductions();
            ViewBag.productions = prs;
            PerformanceVm Prds = new PerformanceVm()
            {
                PerformanceDate = DateTime.Now,
                prods = prs
            };


            return View(Prds);
        }

        [HttpPost]
        public IActionResult AddPerformance(PerformanceVm pvm) {

            pvm.PerformanceID = Guid.NewGuid().ToString();

            Performance pr = new Performance()
            {
                PerformanceID = pvm.PerformanceID,
                PerformanceName = pvm.PerformanceName,
                ProductionName = pvm.ProductionName,
                PerformanceDate = pvm.PerformanceDate,
                PTime = pvm.PTime,
                TotalRevenue = 0
            };

                ManageRepository.SavePerformance(pr);
                return RedirectToAction("BrowsePerformance");
            
        }


/*Edit Performance */

        [HttpGet]
        public IActionResult EditPerformance(string id)
        {
            List<Production> prds = ManageRepository.GetProductions();
            
            Performance prs = ManageRepository.GetPerformanceByID(id);
            PerformanceVm pvm = new PerformanceVm()
            {
                PerformanceID = prs.PerformanceID,
                PerformanceName = prs.PerformanceName,
                ProductionName = prs.ProductionName,
                PerformanceDate = prs.PerformanceDate,
                PTime = prs.PTime,
                prods = prds
            };
                return View(pvm);

        }
        [HttpPost]
        public IActionResult EditPerformance(PerformanceVm pvm)
        {
            
            
                Performance pr = new Performance()
                {
                    PerformanceID = pvm.PerformanceID,
                    PerformanceName = pvm.PerformanceName,
                    ProductionName = pvm.ProductionName,
                    PerformanceDate = pvm.PerformanceDate,
                    PTime = pvm.PTime
                };

                ManageRepository.UpdatePerformance(pr);
                return RedirectToAction("aBrowsePerformance");
                          
        }

/* delete performance */

        public IActionResult DeletePerformance(string id)
        {
            Performance performance = ManageRepository.GetPerformanceByID(id);
            if (performance != null)
            {
                ManageRepository.DeletePerformance(performance);
            }            
            return RedirectToAction("aBrowsePerformance");

        }


        [Authorize]
        [HttpGet]
        public IActionResult BookNow(string id)
        {
            string PatronId = userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            Patron pa = ManageRepository.GetUserById(PatronId);
            Performance pe= ManageRepository.GetPerformanceByID(id);
            BookingVm bvm = new BookingVm()
            {
                FirstName = pa.FirstName,
                LastName = pa.LastName,
                StreetAddress = pa.StreetAddress,
                City = pa.City,
                State = pa.State,
                ZipCode = pa.ZipCode,
                PhoneNumber = pa.PhoneNumber,
                Email = pa.Email,
                PerformanceID = pe.PerformanceID,
                PerformanceName = pe.PerformanceName,
                PerformanceDate = pe.PerformanceDate,
                PerformanceTime = pe.PTime.ToString(),
                ReservedSeats = pe.ReservedSeats,
                TotalPrice = 0
            };
                        

            return View(bvm);
        }
        [HttpPost]
        public IActionResult BookNow(BookingVm bvm)
        {
            Performance pe = ManageRepository.GetPerformanceByID(bvm.PerformanceID);
            if(pe.ReservedSeats==null)
            {
                pe.ReservedSeats = bvm.Seats;
            }
            else
            {
                pe.ReservedSeats = bvm.Seats + ", " + bvm.ReservedSeats;                
            }
            pe.TotalRevenue = bvm.TotalPrice + pe.TotalRevenue;
            ManageRepository.UpdatePerformance(pe);

            string PatronId = userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            Patron pa = ManageRepository.GetUserById(PatronId);
            
            Ticket t = new Ticket()
            {
                TicketID = Guid.NewGuid().ToString(),
                FullName = pa.UserName,
                PatronID = pa.Id,                
                PerformanceName = bvm.PerformanceName,
                Seats = bvm.Seats,
                PurchaseDate = DateTime.Now,
                TotalPrice = bvm.TotalPrice
            };
            ManageRepository.GenerateTicket(t); 

            return RedirectToAction("BrowsePerformance");
        }
        [Authorize]
        public IActionResult ShowMyTickets()
        {
            string PatronId = userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            Patron pa = ManageRepository.GetUserById(PatronId);
            return View(ManageRepository.ShowMyTickets(pa.Id));
        }
        public IActionResult ShowReport()
        {
            List<Performance> performances = ManageRepository.GetPerformances();
            List<ReportVm> reports = new List<ReportVm>();
            foreach (var performance in performances)
            {
                int totalSeats;
                try
                {
                    string[] seats = performance.ReservedSeats
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .ToArray();
                    totalSeats = seats.Length;

                }
                catch
                {
                    totalSeats = 0;
                }
                
                
                
                ReportVm report = new ReportVm()
                {
                    PerformanceName = performance.PerformanceName,
                    ProductionName = performance.ProductionName,
                    PerformanceDate = performance.PerformanceDate,
                    PerformanceTime = performance.PTime.ToString(),
                    ReservedSeat = performance.ReservedSeats,
                    SeatsSold = totalSeats,                    
                    TotalRevenue = performance.TotalRevenue
                };
                reports.Add(report);
            }
            return View(reports);
        }
        



    }
}
