using MvcTemplate.Web.App_Start;
using MvcTemplate.Data;
using MvcTemplate.Data.Common;
using MvcTemplate.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTemplate.Web.Controllers
{
    public class HomeController : Controller
    {
        private IDbRepository<Joke> jokes;
        private IDbRepository<JokeCategory> jokeCategories;

        public HomeController(IDbRepository<Joke> jokes, IDbRepository<JokeCategory> jokeCategories)
        {
            this.jokes = jokes;
            this.jokeCategories= jokeCategories;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}