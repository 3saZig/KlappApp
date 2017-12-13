using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using KlappAppen.Models.ViewModels;
using KlappAppen.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KlappAppen.Controllers
{

    public class AccountController : Controller
    {
        //DBBudgetRepository repository;

        //public AccountController(DBBudgetRepository repository)
        //{
        //    
        //}


        UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> signInManager;
        RoleManager<IdentityRole> roleManager;
        //IdentityDbContext identityContext;

        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager
            //DBBudgetRepository repository
                                                 /*IdentityDbContext identityContext*/)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            //this.repository = repository;
            //this.identityContext = identityContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            //identityContext.Database.EnsureCreated();
            return View();
        }
        

        [HttpGet]
        //[AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
       // [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterVM viewModel, string action)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            if (action == "Skapa konto")
            {
                var result = await userManager.CreateAsync(new IdentityUser(viewModel.UserName), viewModel.Password);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError(
                         nameof(RegisterVM.UserName), "Ogiltligt användarnamn");
                    ModelState.AddModelError(
                        nameof(RegisterVM.Password), "Ogiltligt lösenord");
                }
                var model = new RegisterVM
                {
                    UserName = User.Identity.Name // Read from auth cookie
                };

                return View(model);


            }
            else if (action == "Logga in")
            {
                var result2 = await signInManager.PasswordSignInAsync(
               viewModel.UserName, viewModel.Password, false, false);

                if (!result2.Succeeded)
                {
                    ModelState.AddModelError(
                        nameof(AccountLoginVM.Username), "Felaktigt användarnamn eller lösenord");
                    
                    return View(viewModel);
                }
                return RedirectToAction("Index", "Home");
            }

            //result = "Användare skapad";

            //result = "Användarnamn upptaget";

            return Content(null);
        }




    }
}
