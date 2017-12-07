using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KlappAppen.Models;
using KlappAppen.Models.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KlappAppen.Controllers
{
    public class HomeController : Controller
    {

        DBBudgetRepository repository;

        public HomeController(DBBudgetRepository repository)
        {
            this.repository = repository;
        }

        //GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        //repository.GetAllPersons()
        public IActionResult MainContent()
        {

            return View();
        }

        public IActionResult SetBudget()
        {

            return View(repository.GetAllBudgets());
        }

        //public string GetBudget()
        //{

        //    //return repository.GetAllBudgetsJSON();
        //}

        public IActionResult GiftIdeas()
        {
            return View();
        }


        public IActionResult Settings()
        {
            return View();
        }

        public string GetListJavaScript()
        {
            return repository.GetList();
        }
    }
}
