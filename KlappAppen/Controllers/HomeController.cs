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
    [Authorize]
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


        //=================================================================================================
        //IACTIONRESULTS
        //=================================================================================================

        //GET: /<controller>/
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }


        //repository.GetAllPersons()
        [Authorize]
        public IActionResult MainContent()
        {
            return View();
        }


        [Authorize]        
        public IActionResult SetBudget()
        {
            return View();
        }


        [AllowAnonymous]
        public IActionResult GiftIdeas()
        {
            return View();
        }


        [Authorize]
        public IActionResult MyPages()
        {
            return View();
        }



        //=================================================================================================
        //KLAPPLISTAN
        //=================================================================================================


        //för att lägga till en post i klapplistan. Här ryms Receiver, Name, Price och BudgetId
        public string AddPersonJavaScript(HomeMainContentVM homeMainVM)
        {
            return repository.AddPerson(homeMainVM);
        }


        [HttpPost]
        public string SaveChangesJavascript(int id, string receiver, string gift, int price)
        {
            var model = JsonConvert.SerializeObject(repository.EditPerson(id, receiver, gift, price));
            return model;
        }


        public string DeletePersonJavascript(int id)
        {
            return repository.DeletePerson(id);
        }

        public string GetListOfGifts(int id)
        {
            return JsonConvert.SerializeObject(repository.GetGifts(id));
        }

        //=================================================================================================
        //SET BUDGET
        //=================================================================================================


        //skapa en ny budget
        public string AddBudgetJavaScript(BudgetsVM budgetVM)
        {
            string userId = userManager.GetUserId(HttpContext.User);
            //Här hämtar vi vår användare
            return repository.AddNewBudget(budgetVM, userId);
        }

        //hämtar alla budgets en användare har
        public string GetBudget()
        {
            string userId = userManager.GetUserId(HttpContext.User);
            return repository.GetBudgets(userId);
        }



        //=================================================================================================
        //CHART
        //=================================================================================================


        //returnerar Name och Price från Gifts-tabellen
        public string CreateChart()
        {
            return repository.GetAllGifts();
        }

        public string BudgetForChart(int id)
        {
                return repository.GetBudgetTotalAmountFromId(id);
        }



        //=================================================================================================
        //LOGIN
        //=================================================================================================


        public async Task LogOut()
        {
            await signInManager.SignOutAsync();
        }



        //=================================================================================================
        //GRAVEYARD
        //=================================================================================================


        //public string ShowListFromBudgetId(int id)
        //{
        //    var model = JsonConvert.SerializeObject(repository.EditPerson(id));
        //    return model;
        //}


    }
}
