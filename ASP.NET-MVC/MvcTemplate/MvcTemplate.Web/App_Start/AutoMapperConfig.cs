using MvcTemplate.Web.Infrastructure.Mapping;
using System.Reflection;

namespace MvcTemplate.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterAutoMapper()
        {
            var autoMapperConfig = new AutoMapperConfiguration();
            autoMapperConfig.Execute(Assembly.GetExecutingAssembly());
        }
    }
}