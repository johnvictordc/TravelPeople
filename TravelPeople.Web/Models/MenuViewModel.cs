using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPeople.Commons.Interfaces;
using TravelPeople.Commons.Objects;

namespace TravelPeople.Web.Models
{
    public class MenuViewModel : Node, IMenu
    {
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
    }
}