using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPeople.Commons.Objects
{
    public class Content : Node
    {
        public string name
        {
            get;

            set;
        }

        public string content
        {
            get;

            set;
        }

     
        public long type
        {
            get;

            set;
        }

        public string alias
        {
            get;

            set;
        }

        public string metaDescription
        {
            get;

            set;
        }

        public string metaTags
        {
            get;

            set;
        }
    }
}
