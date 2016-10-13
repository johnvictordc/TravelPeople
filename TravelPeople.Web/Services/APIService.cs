using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TravelPeople.Web.Services
{
    public class APIService
    {

        private RestRequest request;
        private RestClient rest;

        public APIService()
        {
            this.request = new RestRequest();
            this.rest = new RestClient();
            this.rest.BaseUrl = new Uri(ConfigurationManager.AppSettings["base_url"].ToString());
        }

        public void SetRequest(String resource, Method method, DataFormat format = DataFormat.Json)
        {
            this.request = new RestRequest(resource, method);
            request.RequestFormat = format;
        }

        public IRestResponse Execute()
        {
            return rest.Execute(request);
        }

    }
}