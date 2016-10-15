using SACS.Library.Configuration;
using SACS.Library.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPeople.Web.Services;

namespace TravelPeople.Web.Factories
{
    public static class RestFactory
    {

        public static APIService API()
        {
            return new APIService();
        }

        public static APIService API(string baseUrl)
        {
            return new APIService(baseUrl);
        }

        public static RestClient Sabre()
        {
            IConfigProvider config = ConfigFactory.CreateForRest();
            RestAuthorizationManager restAuthorizationManager = new RestAuthorizationManager(config);
            return new RestClient(restAuthorizationManager, config);
        }

    }
}