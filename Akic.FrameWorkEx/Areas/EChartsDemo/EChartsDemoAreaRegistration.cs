using System.Web.Mvc;

namespace Akic.FrameWorkEx.Areas.EChartsDemo
{
    public class EChartsDemoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "EChartsDemo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "EChartsDemo_default",
                "EChartsDemo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}