using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using TravelPeople.Commons.Utils;

namespace TravelPeople.Web.Controllers
{
    public class BaseController : Controller
    {
        #region UTILITIES
        public ActionResult CustomMessage(CustomException message)
        {
            return View("CustomMessage", message);
        }

        public ActionResult CustomMessage(string message)
        {
            return View("CustomMessage", JsonConvert.DeserializeObject<CustomException>(message));
        }

        public ActionResult NotFound()
        {
            return View("CustomMessage", new CustomException(TravelPeople.Commons.Utils.Message.CONTENT_NOT_FOUND));
        }

        public void SetTitle(string title = null)
        {
            ViewBag.Title = title;
        }

        public void SetMessage(string message, MESSAGE_TYPE type)
        {
            Session["MESSAGE"] = new CustomException(message, type);
        }

        public void MetaInit(string tags, string description)
        {
            ViewBag.MetaTags = tags;
            ViewBag.MetaDescription = description;
        }
        #endregion
    }
}