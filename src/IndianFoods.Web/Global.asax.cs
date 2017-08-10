using IndianFoods.Web.Controllers;
using System;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace IndianFoods.Web
{
    public class MvcApplication : UmbracoApplication
    {
        public override void Init()
        {
            base.Init();
        }

        protected override void OnApplicationStarted(object sender, EventArgs e)
        {
            base.OnApplicationStarted(sender, e);
            Application_Start();
            
        }
        protected void Application_Start()
        {
            var mediaPath = ConfigurationManager.AppSettings["MediaPath"];           
           
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //WebApiConfig.Register(System.Web.Http.GlobalConfiguration.Configuration);
            ViewEngines.Engines.Remove(new WebFormViewEngine());      
            //MemberService.Created += MemberService_Created;

            //AutoMapperProfile.Configure();
        }


    }
}
