using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TravelPeople.Web.Helpers
{
    public class APIHelper : RestRequest
    {

        private RestRequest _request;
        private RestClient _rest;

        public RestRequest request 
        { 
            get; 
            set; 
        }

        public RestClient rest 
        { 
            get; 
            set; 
        }

        public APIHelper()
        {
            this.request = new RestRequest();
            this.rest = new RestClient();
            this.rest.BaseUrl = new Uri(ConfigurationManager.AppSettings["base_url"].ToString());
        }

        public APIHelper(string baseUrl)
        {
            this.request = new RestRequest();
            this.rest = new RestClient();
            this.rest.BaseUrl = new Uri(baseUrl);
        }

        public void SetRequest(String resource, Method method, DataFormat format = DataFormat.Json)
        {
            this.request = new RestRequest(resource, method);
            this.request.RequestFormat = format;
        }

        public void AddBody(object obj)
        {
            this.request.AddBody(obj);
        }

        public IRestResponse Execute()
        {
            return rest.Execute(this.request);
        }

        public object DeserializeResult(IRestResponse response)
        {
            return JsonConvert.DeserializeObject(response.Content);
        }

    }
}