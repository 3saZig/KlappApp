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

        DBPersonsRepository repository;
        public HomeController(DBPersonsRepository repository)
        {
            this.repository = repository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            repository.GetAllPersons();
            return Content("");
        }

        public IActionResult MainContent()
        {            
            return Content("MainContent");
        }

        public IActionResult SetBudget()
        {            
            return Content("SetBudget");
        }
    }
}
