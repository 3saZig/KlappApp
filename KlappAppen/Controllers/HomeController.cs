using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KlappAppen.Models;
using KlappAppen.Models.Entities;
using Newtonsoft.Json;

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

        public string CreateChart()
        {
            return repository.GetAllGifts();
        }

        //public string Budget()
        //{
        //    return repository.CreateBudget();
        //}

        public IActionResult SetBudget()
        {
            return View();

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

        public string DeletePersonJavascript(int id)
        {
            return repository.DeletePerson(id);
        }
    }
}
