using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DucksAndDinner.Api.Models;

namespace DucksAndDinner.Api.Controllers
{
    public class DuckController : Controller
    {
        readonly IDuckRepository _duckRepository;

        public DuckController(IDuckRepository duckRepository)
        {
            _duckRepository = duckRepository;
        }

        // GET: Duck
        public ActionResult Index()
        {
            return View("index");
        }

        [HttpPost]
        public ActionResult BringADuck(Duck newDuck)
        {
            _duckRepository.Save(newDuck);

            return View("index");
        }
    }
}