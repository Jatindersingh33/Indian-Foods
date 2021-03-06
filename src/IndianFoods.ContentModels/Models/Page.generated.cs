//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder v3.0.7.99
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder;
using Umbraco.ModelsBuilder.Umbraco;

namespace IndianFoods.ContentModels
{
	/// <summary>Page</summary>
	[PublishedContentModel("page")]
	public partial class Page : PublishedContentModel, IPageVisibility
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "page";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public Page(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Page, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Exclude From Sitemap
		///</summary>
		[ImplementPropertyType("excludeFromSitemap")]
		public bool ExcludeFromSitemap
		{
			get { return IndianFoods.ContentModels.PageVisibility.GetExcludeFromSitemap(this); }
		}

		///<summary>
		/// Hide From Navigation
		///</summary>
		[ImplementPropertyType("hideFromNavigation")]
		public bool HideFromNavigation
		{
			get { return IndianFoods.ContentModels.PageVisibility.GetHideFromNavigation(this); }
		}

		///<summary>
		/// Redirect URL
		///</summary>
		[ImplementPropertyType("redirectURL")]
		public IPublishedContent RedirectUrl
		{
			get { return IndianFoods.ContentModels.PageVisibility.GetRedirectUrl(this); }
		}
	}
}
