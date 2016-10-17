using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPeople.Commons.Objects
{
    public class Country
    {

        public Country(int id, string code, string name)
        {
            this.id = id;
            this.code = code;
            this.name = name;
        }

        public int id { get; set; }

        public string code { get; set; }

        public string name { get; set; }

    }
}
