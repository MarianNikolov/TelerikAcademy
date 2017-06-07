using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroesUniverse.ConsoleClient.JsonModels
{

    public class DataRoot
    {
        public JsonHero[] data { get; set; }
    }

    public class JsonHero
    {
        public string name { get; set; }
        public string secretIdentity { get; set; }
        public JsonCity city { get; set; }
        public string alignment { get; set; }
        public string story { get; set; }
        public string[] powers { get; set; }
        public string[] fractions { get; set; }
    }

    public class JsonCity
    {
        public string name { get; set; }
        public string country { get; set; }
        public string planet { get; set; }
    }

}
