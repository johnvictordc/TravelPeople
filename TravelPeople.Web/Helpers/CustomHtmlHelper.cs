using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace TravelPeople.Web.Helpers
{
    public static class CustomHtmlHelper
    {
        public static MvcHtmlString EncodedReplace(this HtmlHelper helper, string input, string pattern, string replacement)
        {
            return new MvcHtmlString(Regex.Replace(helper.Encode(input), pattern, replacement));
        }

        public static MvcHtmlString MyValidationSummary(this HtmlHelper helper, string validationMessage = "")
        {
            string retVal = "";
            if (helper.ViewData.ModelState.IsValid)
                return new MvcHtmlString("");
            retVal += "<div class='notification-warnings alert alert-danger'>";
            retVal += "<div class='text'>";
            foreach (var key in helper.ViewData.ModelState.Keys)
            {
                foreach (var err in helper.ViewData.ModelState[key].Errors)
                    retVal += "<div class='alert-item'><span class='fa fa-times'></span> " + helper.Encode(helper.Raw(err.ErrorMessage)) + "</div>";
            }
            retVal += "</div></div>";
            return new MvcHtmlString(HttpUtility.HtmlDecode(retVal));
        }
    }
}