using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPeople.Commons.Interfaces
{
    public interface IBlock
    {
        string name { get; set; }

        string content { get; set; }

        string alias { get; set; }

        string position { get; set; }

        string headerText { get; set; }
    }
}
