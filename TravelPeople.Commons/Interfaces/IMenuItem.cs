using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPeople.Commons.Interfaces
{
    public interface IMenuItem
    {

        long id { get; set; }

        string text { get; set; }

        string link { get; set; }

        long menu { get; set; }

        bool authenticated { get; set; }

    }
}
