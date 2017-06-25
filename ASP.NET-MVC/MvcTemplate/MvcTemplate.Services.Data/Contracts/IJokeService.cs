using MvcTemplate.Data.Models;
using System.Linq;

namespace MvcTemplate.Services.Data.Contracts
{
    public interface IJokeService
    {
        IQueryable<Joke> GetAll();
    }
}
