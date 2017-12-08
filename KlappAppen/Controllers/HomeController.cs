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

        public HomeController(DBBudgetRepository repository)
        {
            this.repository = repository;
        }

        //GET: /<controller>/
        [AllowAnonymous]
        public IActionResult Index()
        {
            string result = repository.GetAllGifts();
            return Content($"Här ska det vara tomt: {result}");//  View(MyPages());
        }

        //repository.GetAllPersons()
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
            
            return JsonConvert.SerializeObject(repository.AddPerson(homeMainVM));
        }

        
        public string AddBudgetJavaScript(HomeSetBudgetVM budgetVM)
        {

            return JsonConvert.SerializeObject(repository.AddNewBudget(budgetVM));

            
        }

        //public string Budget()
        //{
        //    return repository.CreateBudget();
        //}

        [Authorize]
        public IActionResult SetBudget()
        {
            return View();

        }

        public string GetBudget()
        {

            throw new NotImplementedException();
            // repository.GetAllBudgetsJSON();
        }

        [Authorize]
        public IActionResult GiftIdeas()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult MyPages()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Settings() //Här vill jag ha en inparameter från html
        //{
        //    return View(); //här vill jag kalla på javascript och returnera ny vy. 
        //}


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
