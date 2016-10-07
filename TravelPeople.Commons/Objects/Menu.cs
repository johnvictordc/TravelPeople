using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPeople.Commons.Interfaces;

namespace TravelPeople.Commons.Objects
{
    public class Menu : Node, IMenu
    {

        public Menu()
        {
            this.items = new List<MenuItem>();
        }

        public string name
        {
            get;
            set;
        }

        public string alias
        {
            get;
            set;
        }

        public string position
        {
            get;
            set;
        }

        public string header_text
        {
            get;
            set;
        }


        public List<MenuItem> items
        {
            get;
            set;
        }
    }
}
