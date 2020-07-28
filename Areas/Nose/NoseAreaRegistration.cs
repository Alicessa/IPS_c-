using System.Web.Mvc;

namespace IPS.Areas.Nose
{
    public class NoseAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Nose";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Nose_default",
                "Nose/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}