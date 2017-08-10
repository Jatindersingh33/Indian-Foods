using IndianFoods.ContentModels;
using IndianFoods.ContentModels.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace IndianFoods.Web.Repositories
{
    public class NavigationRepository
    {
        private readonly UmbracoHelper _umbracoHelper;
        private readonly Regex _regex;

        public NavigationRepository(UmbracoContext umbracoContext)
        {
            _umbracoHelper = new UmbracoHelper(umbracoContext);
            _regex = new Regex(@"( \(\d+\))", RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }

        public Page Root()
        {
            return _umbracoHelper.TypedContentAtRoot().FirstOrDefault() as Page;
        }
        
        public IEnumerable<MenuItem> Children(IPublishedContent currentPage)
        {
            // Build main navigation based on criteria of specific categories of child nodes
            return (from node in currentPage.AncestorOrSelf(1).Children.Where("Visible")
                    let active = node.Id == currentPage.Id
                    select new MenuItem
                    {
                        Visible = node.IsVisible(),
                        Active = active,
                        Name = _regex.Replace(node.Name, ""),
                    }).ToList();
        }

        public IEnumerable<MenuItem> Ancestors(IPublishedContent currentPage)
        {
            return (from node in currentPage.AncestorsOrSelf().OrderBy("Level")
                    let active = node.Id == currentPage.Id
                    select new MenuItem
                    {
                        Visible = node.IsVisible(),
                        Active = active,
                        Name = _regex.Replace(node.Name, ""),
                        Url = node.Url  //TODO: when ancestor is ProductCategory link is not valid
                    }).ToList();
        }
    }
}