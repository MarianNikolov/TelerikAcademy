using MvcTemplate.Data.Common;
using MvcTemplate.Data.Models;
using MvcTemplate.Services.Data.Contracts;
using System.Linq;

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

        public JokeCategory EnsureCategory(string name)
        {
            var category = this.jokeCategories.All().FirstOrDefault(x => x.Name == name);

            if (category != null)
            {
                return category;
            }

            category = new JokeCategory { Name = name };

            this.jokeCategories.Add(category);
            this.jokeCategories.Save();

            return category;
        }
    }
}
