using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPeople.Commons.Interfaces;

namespace TravelPeople.Commons.Objects
{
    public class Content : Node, IContent
    {

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

        public string meta_description
        {
            get;

            set;
        }

        public string meta_tags
        {
            get;

            set;
        }
    }
}
