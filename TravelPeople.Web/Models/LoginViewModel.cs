using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPeople.Commons.Interfaces;

namespace TravelPeople.Web.Models
{
    public class LoginViewModel : IUser
    {

        public string username
        {
            get;
            set;
        }

        public string password
        {
            get;
            set;
        }

        public string test()
        {
            return "asdasd";
        }

    }
}