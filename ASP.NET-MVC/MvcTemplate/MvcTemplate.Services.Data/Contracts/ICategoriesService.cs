using MvcTemplate.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcTemplate.Services.Data.Contracts
{
    public interface ICategoriesService
    {
        IQueryable<JokeCategory> GetAll();
    }
}
