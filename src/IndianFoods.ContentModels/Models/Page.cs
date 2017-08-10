using IndianFoods.ContentModels;
using IndianFoods.ContentModels.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using Umbraco.Core;
using Umbraco.ModelsBuilder;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace IndianFoods.ContentModels
{
    [IgnorePropertyType("objectGraphImage")]
    public partial class Page
    {
        private NameValueCollection _settings;

        public IEnumerable<MenuItem> MainNavigation { get; set; }
        public virtual IEnumerable<MenuItem> CrumbNavigation { get; set; }
       
        public string RootUrl => UmbracoContext.Current.UrlProvider.GetUrl(this.AncestorOrSelf<HomePage>(1).Id);

        public CultureInfo CurrentCulture => Thread.CurrentThread.CurrentCulture;

        public string GetDictionaryValue(string key, CultureInfo cultureInfo = null, DictionaryFormatOption formatOption = DictionaryFormatOption.None)
        {
            var result = key;
            var dictionaryItem = UmbracoContext.Current.Application.Services.LocalizationService.GetDictionaryItemByKey(key);
            cultureInfo = cultureInfo == null ? this.CurrentCulture : cultureInfo;
            if (dictionaryItem != null)
            {
                var translation = dictionaryItem.Translations.SingleOrDefault(x => x.Language.CultureInfo.Equals(cultureInfo));
                if (translation != null && !string.IsNullOrWhiteSpace(translation.Value))
                {
                    result = translation.Value;
                }
            }
            switch (formatOption)
            {
                case DictionaryFormatOption.UpperCase:
                    return (cultureInfo).TextInfo.ToUpper(result);
                case DictionaryFormatOption.LowerCase:
                    return (cultureInfo).TextInfo.ToLower(result);
                case DictionaryFormatOption.ProperCase:
                    return (cultureInfo).TextInfo.ToTitleCase(result);
                case DictionaryFormatOption.None:
                default:
                    return result;
            }
        }

        public NameValueCollection SiteSettings => _settings == null ? _settings = ConfigurationManager.AppSettings : _settings;

        #region Page Footer

        public IFooter SiteFooter => this.AncestorOrSelf<HomePage>(1);

        public IHeader SiteHeader => this.AncestorOrSelf<HomePage>(1);

        #endregion
    }
}