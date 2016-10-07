using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPeople.Commons.Objects;

namespace TravelPeople.Commons.Interfaces
{
    public interface IMenu
    {
        string name { get; set; }

        string alias { get; set; }

        string position { get; set; }

        string header_text { get; set; }

        List<MenuItem> items { get; set; }

    }
}
