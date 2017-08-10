using IndianFoods.ContentModels;
using IndianFoods.Web.Repositories;
using System.Web.Mvc;
using Umbraco.Web.Mvc;


namespace IndianFoods.Web.Controllers
{
    public class BaseController : RenderMvcController
    {
        // GET: Base
        public ViewResult Index(Page model)
        {
            return View(null, model);
        }

        public ViewResult View(string view, Page model)
        {
            var navRepo = new NavigationRepository(UmbracoContext);
            model.MainNavigation = navRepo.Children(CurrentPage);
            //model.CrumbNavigation = navRepository.Ancestors(CurrentPage);

            return View(model);
        }
    }
}