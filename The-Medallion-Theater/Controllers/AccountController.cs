using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using The_Medallion_Theater.Models;

namespace The_Medallion_Theater.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Patron> userManager;
        private readonly SignInManager<Patron> signInManager;

        public AccountController(UserManager<Patron> userManager, SignInManager<Patron> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
/*Sign up*/
        [HttpGet]
        public IActionResult Signup() => View();

        [HttpPost]
        public async Task<IActionResult> Signup(PatronVm pvm)
        {
            if (ModelState.IsValid)
            {
                Patron patron = new Patron()
                {
                    UserName = pvm.FirstName + "_" + pvm.LastName,
                    FirstName = pvm.FirstName,
                    LastName = pvm.LastName,
                    Email = pvm.Email,
                    StreetAddress = pvm.StreetAddress,
                    City = pvm.City,
                    State = pvm.State,
                    ZipCode = pvm.ZipCode,
                    PhoneNumber = pvm.Phone.ToString()
                };
                IdentityResult result = await userManager.CreateAsync(patron, pvm.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Loginurl");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                }

                
            }
            return View(pvm);
        }

/*Login with Url */

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            LoginVM li = new LoginVM();
            li.Returnurl = returnUrl;   
            return View(li);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM li)
        {
            if (ModelState.IsValid)
            {
                Patron? patron= await userManager.FindByEmailAsync(li.Email);
                if (patron != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager
                        .PasswordSignInAsync(patron, li.Password, false, false);

                    if (result.Succeeded)
                    {
                        if (li.Returnurl != null)
                        {
                            return Redirect(li.Returnurl ?? "/");
                        }
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError(nameof(li.Email), "Login Failed: Invalid Email or Password Combination");
                    RedirectToAction("Login");
                }
            }
            return View(li);
        }

/*Login without Url*/
        [HttpGet]
        public IActionResult Loginurl()
        {
            LoginVM li = new LoginVM();
            li.Returnurl = "none";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Loginurl(LoginVM li)
        {
            if (ModelState.IsValid)
            {
                Patron? patron = await userManager.FindByEmailAsync(li.Email);
                if (patron != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager
                        .PasswordSignInAsync(patron, li.Password, false, false);

                    if (result.Succeeded)
                    {

                        return RedirectToAction("BrowsePerformance", "Theater");
                    }
                    else
                    {
                        ModelState.AddModelError(nameof(li.Email), "Login Failed: Invalid Email or Password Combination");
                        RedirectToAction("Loginurl");
                    }

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Login Failed: User not found");
                    RedirectToAction("Loginurl");
                }
                

            }

            return View(li);
        }

/*Log out*/
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }




    }
}
