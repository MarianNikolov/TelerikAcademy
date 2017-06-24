using MvcTemplate.Web.App_Start;
using MvcTemplate.Data;
using MvcTemplate.Data.Common;
using MvcTemplate.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MvcTemplate.Web.Controllers
{
    public class HomeController : Controller
    {
        private IDbRepository<Joke> jokes;
        private IDbRepository<JokeCategory> jokeCategories;
        private DbContext context;

        public HomeController(IDbRepository<Joke> jokes, IDbRepository<JokeCategory> jokeCategories, DbContext context)
        {
            this.jokes = jokes;
            this.jokeCategories= jokeCategories;
            this.context = context;
        }

        public ActionResult Index()
        {
            //this.jokeCategories.Add(new JokeCategory { Name = "uuuuf" });
            var category = this.jokeCategories.All().ToList()[0];
            this.jokes.Add(new Joke { Content = "a" , Category = category});
            this.jokes.Add(new Joke { Content = "asdsfgdf" , CategoryId = 2});
            this.context.SaveChanges();
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