using System;
using System.Linq;
using MvcTemplate.Data.Models;
using MvcTemplate.Services.Data.Contracts;
using MvcTemplate.Data.Common;

namespace MvcTemplate.Services.Data
{
    public class CategoriesService : ICategoriesService
    {
        IDbRepository<JokeCategory> jokeCategories;

        public CategoriesService(IDbRepository<JokeCategory> jokeCategories)
        {
            this.jokeCategories = jokeCategories;
        }

        public IQueryable<JokeCategory> GetAll()
        {
            var jokeCategories = this.jokeCategories.All().OrderBy(x => x.Name);

            return jokeCategories;
        }
    }
}
