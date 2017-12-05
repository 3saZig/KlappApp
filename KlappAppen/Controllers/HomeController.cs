using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KlappAppen.Models;

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
            var model = repository.GetAllPersons();
            return View(model);
        }
    }
}
