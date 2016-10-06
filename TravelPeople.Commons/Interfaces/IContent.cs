using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPeople.Commons.Interfaces
{
    public interface IContent
    {

        string content { get; set; }

        long type { get; set; }

        string alias { get; set; }

        string meta_description { get; set; }

        string meta_tags { get; set; }

    }
}
