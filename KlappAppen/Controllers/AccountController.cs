using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using KlappAppen.Models.ViewModels;
using KlappAppen.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KlappAppen.Controllers
{

    public class AccountController : Controller
    {
        DBBudgetRepository repository;

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
            RoleManager<IdentityRole> roleManager,
            DBBudgetRepository repository
                                                 /*IdentityDbContext identityContext*/)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.repository = repository;
            //this.identityContext = identityContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            //identityContext.Database.EnsureCreated();
            return Content("Identity tabeller skapade!");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
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
                    //modelstate add error
                    /*result.Errors.First.message()*/;
                    return View(viewModel);

                }
                
            }
            else if (action == "Logga in")
            {
                var result = await signInManager.PasswordSignInAsync(
                    viewModel.UserName,
                    viewModel.Password, false, false);
                return View(viewModel); //Här ska det nog vara redirect men har ingen sida dit.
            }

            
            
                //result = "Användare skapad";
           
                //result = "Användarnamn upptaget";

            return Content(null);
        }
      



    }
}
