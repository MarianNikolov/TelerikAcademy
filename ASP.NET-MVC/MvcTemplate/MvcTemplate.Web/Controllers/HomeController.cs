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
using MvcTemplate.Web.ViewModels.Home;
using MvcTemplate.Web.Infrastructure.Mapping;
using MvcTemplate.Services.Data.Contracts;

namespace MvcTemplate.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJokeService jokesServices;
        private readonly ICategoriesService categoriesServices;

        public HomeController(IJokeService jokesServices, ICategoriesService categoriesServices)
        {
            this.jokesServices = jokesServices;
            this.categoriesServices = categoriesServices;
        }

        public ActionResult Index()
        {
            var jokes = jokesServices.GetAll()
                .To<JokeViewModel>().ToList();

            var categories = this.categoriesServices.GetAll()
                .To<JokeCategoryViewModel>().ToList();

            var viewModel = new IndexViewModel
            {
                Jokes = jokes,
                Categories = categories
            };

            return View(viewModel);
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