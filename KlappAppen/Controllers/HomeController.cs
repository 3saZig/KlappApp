using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KlappAppen.Models;
using KlappAppen.Models.Entities;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using KlappAppen.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KlappAppen.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        DBBudgetRepository repository;
        UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> signInManager;
        //RoleManager<IdentityRole> roleManager;
        //IdentityDbContext identityContext;

        //RoleManager<IdentityRole> roleManager
        //DBBudgetRepository repository
        /*IdentityDbContext identityContext*/
        //this.roleManager = roleManager;

        public HomeController(
            DBBudgetRepository repository,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
            this.repository = repository;
            this.signInManager = signInManager;
        }

        //GET: /<controller>/
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        //repository.GetAllPersons()
        //[Authorize]
        public IActionResult MainContent()
        {
            return View();
        }

        public string CreateChart()
        {
            return repository.GetAllGifts();
        }


        public string AddPersonJavaScript(HomeMainContentVM homeMainVM)
        {
            return repository.AddPerson(homeMainVM);
        }

        public async Task LogOut()
        {
            await signInManager.SignOutAsync();
        }



        public string AddBudgetJavaScript(BudgetsVM budgetVM)
        {
            string userId = userManager.GetUserId(HttpContext.User);  //Här hämtar vi vår användare
            return repository.AddNewBudget(budgetVM, userId);
        }

        // [Authorize]        
        public IActionResult SetBudget()
        {
            return View();

        }

        public string GetBudget()
        {
            string userId = userManager.GetUserId(HttpContext.User);
            return repository.GetBudgets(userId);
        }

        [AllowAnonymous]
        public IActionResult GiftIdeas()
        {
            return View();
        }

        //  [Authorize]
        public IActionResult MyPages()
        {
            return View();
        }

        public string GetListJavaScript(int budgetId)
        {
            return repository.GetGifts(budgetId);
        }

        public string DeletePersonJavascript(int id)
        {
            return repository.DeletePerson(id);
        }

        [HttpPost]
        public string SaveChangesJavascript(int id, string receiver, string gift, int price)
        {
            var model = JsonConvert.SerializeObject(repository.EditPerson(id, receiver, gift, price));
            return model;
        }


    }
}
