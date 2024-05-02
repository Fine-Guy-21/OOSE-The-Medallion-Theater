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
            return View();
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
