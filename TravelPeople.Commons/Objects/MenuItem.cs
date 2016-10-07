using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPeople.Commons.Interfaces;

namespace TravelPeople.Commons.Objects
{
    public class MenuItem : Node, IMenuItem, ICreator
    {

        public string text
        {
            get;
            set;
        }

        public string link
        {
            get;
            set;
        }

        public long menu
        {
            get;
            set;
        }

        public bool authenticated
        {
            get;
            set;
        }
    }
}
