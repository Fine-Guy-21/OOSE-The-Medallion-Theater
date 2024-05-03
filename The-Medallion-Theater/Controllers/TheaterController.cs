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
                    PTime = pvm.PTime
                };

                ManageRepository.SavePerformance(pr);
                return RedirectToAction("BrowsePerformance");
            
        }


/*Edit */

        [HttpGet]
        public IActionResult EditPerformance(string id)
        {
            List<Performance> prds = ManageRepository.GetPerformances();
            Performance prs = ManageRepository.GetPerformanceByID(id);
            PerformanceVm pvm = new PerformanceVm()
            {
                PerformanceID = prs.PerformanceID,
                PerformanceName = prs.PerformanceName,
                ProductionName = prs.ProductionName,
                PerformanceDate = prs.PerformanceDate,
                PTime = prs.PTime
            };

            ViewData["Prs"] = prds; 
            return View(pvm);

        }
        [HttpPost]
        public IActionResult EditPerformance(PerformanceVm pvm)
        {
            
            if (ModelState.IsValid)
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
                return RedirectToAction("BrowsePerformance");
                
            }            
            ;
            return View();

        }

/* delete performance */

        public IActionResult DeletePerformance(string id)
        {
            Performance pr = ManageRepository.GetPerformanceByID(id);
            if (pr != null)
            {
                ManageRepository.DeletePerformance(pr);
            }
            return RedirectToAction("BrowsePerformance");

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

        public IActionResult GenerateTicket(Ticket ticket)
        {
            return View();
        }

    }
}
