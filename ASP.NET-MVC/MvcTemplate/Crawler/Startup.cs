using AngleSharp;
using AngleSharp.Dom;
using MvcTemplate.Data;
using MvcTemplate.Data.Common;
using MvcTemplate.Data.Models;
using MvcTemplate.Services.Data;
using System;

namespace Crawler
{
    public class Startup
    {
        static void Main()
        {
            // TODO: Add DI container an AutoMapper
            var db = new ApplicationDbContext();
            var dbRopository = new DbRepository<JokeCategory>(db);
            var categoryesService = new CategoriesService(dbRopository);

            // AngleSharp configurations
            IConfiguration configuration = Configuration.Default.WithDefaultLoader();
            IBrowsingContext browsingContex = BrowsingContext.New(configuration);
            long countOfAddedJokes = 0;
            for (int i = 1; i < 65000; i++)
            {
                string url = $"http://vicove.com/vic-{i}";
                IDocument document = browsingContex.OpenAsync(url).Result;
                string jokeContent = document.QuerySelector("#content_box .post-content p").TextContent.Trim();
                string categoryName = document.QuerySelector("#content_box .thecategory a").TextContent.Trim();

                bool isValidJoke = !string.IsNullOrWhiteSpace(jokeContent);
                bool isValidCategory = !string.IsNullOrWhiteSpace(categoryName);

                if (isValidJoke && isValidCategory)
                {
                    countOfAddedJokes++;

                    JokeCategory category = categoryesService.EnsureCategory(categoryName);
                    Joke joke = new Joke
                    {
                        Content = jokeContent,
                        Category = category
                    };

                    db.Jokes.Add(joke);
                    db.SaveChanges();

                    if (countOfAddedJokes % 100 == 0)
                    {
                        Console.WriteLine($"Added {countOfAddedJokes} jokes");
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine($"--- DONE => {countOfAddedJokes} joke added");
        }
    }
}
