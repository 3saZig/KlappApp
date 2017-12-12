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

        public HomeController(DBBudgetRepository repository)
        {
            this.repository = repository;
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

       
        public string AddBudgetJavaScript(HomeSetBudgetVM budgetVM)
        {
            return repository.AddNewBudget(budgetVM);
        }
        
       // [Authorize]        
        public IActionResult SetBudget()
        {
            return View();

        }

        public string GetBudget()
        {
            return repository.GetBudget();
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
                
        public string GetListJavaScript()
        {
            return repository.GetList();
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
