using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPeople.Commons.Interfaces
{
    public interface INode
    {
        string id { get; set; }

        string name { get; set; }

        Boolean enabled { get; set; }
    }
}
