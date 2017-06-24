using MvcTemplate.Data.Models;
using MvcTemplate.Web.Infrastructure.Mapping;

namespace MvcTemplate.Web.ViewModels.Home
{
    public class JokeViewModel : IMapFrom<Joke>
    {
        public string Content { get; set; }
    }
}