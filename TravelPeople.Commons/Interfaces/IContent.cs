using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPeople.Commons.Interfaces
{
    public interface IContent
    {
        string name { get; set; }

        string content { get; set; }

        long type { get; set; }

        string meta_description { get; set; }

        string meta_tags { get; set; }

    }
}
