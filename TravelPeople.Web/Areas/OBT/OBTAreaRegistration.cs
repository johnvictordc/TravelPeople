using System.Web.Mvc;

namespace TravelPeople.Web.Areas.OBT
{
    public class OBTAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "OBT";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "OBT_default",
                "OBT/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}