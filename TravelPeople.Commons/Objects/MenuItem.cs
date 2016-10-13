using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPeople.Commons.Objects
{
    public class MenuItem : Node
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
