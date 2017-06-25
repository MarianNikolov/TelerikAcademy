using MvcTemplate.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcTemplate.Data.Models;
using MvcTemplate.Data.Common;
using MvcTemplate.Web.Infrastructure.Mapping;

namespace MvcTemplate.Services.Data
{
    public class JokeService : IJokeService
    {
        private IDbRepository<Joke> jokes;

        public JokeService(IDbRepository<Joke> jokes)
        {
            this.jokes = jokes;
        }

        public IQueryable<Joke> GetAll()
        {
            var jokes = this.jokes
                .All()
                .OrderBy(x => x.CreatedOn);

            return jokes;
        }
    }
}
