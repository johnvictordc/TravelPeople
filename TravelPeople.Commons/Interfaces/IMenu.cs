using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPeople.Commons.Interfaces
{
    public interface IMenu
    {

        string alias { get; set; }

        string position { get; set; }

        string header_text { get; set; }

    }
}
