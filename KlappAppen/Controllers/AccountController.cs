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

        public AccountController(DBBudgetRepository repository)
        {
            this.repository = repository;
        }


        UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> signInManager;
        RoleManager<IdentityRole> roleManager;
        //IdentityDbContext identityContext;

        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager//,
                                                 /*IdentityDbContext identityContext*/)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
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
        public async Task<IActionResult> Register(RegisterVM viewModel)
        {

            var result = ""; 

            if (userManager.FindByNameAsync(viewModel.UserName) == null)
            {
                await userManager.CreateAsync(new IdentityUser(viewModel.UserName), viewModel.Password);
                result = "Användare skapad";
            }
            else
            {
                result = "Användarnamn upptaget";
            }

            return Content(result);
        }
    }
}
