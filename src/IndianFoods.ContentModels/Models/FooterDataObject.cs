using Umbraco.Core.Models;
using Our.Umbraco.Vorto.Extensions;
using Umbraco.ModelsBuilder;
using Umbraco.Web;

namespace IndianFoods.ContentModels
{
    public partial class FooterDataObject
    {
        public const string DataItemProperty = "footerData";
        

        internal static FooterDataObject DataItem(IFooter that)
        {
            var defaultDataItem = new FooterDataObject(that.HasVortoValue(DataItemProperty) ? that.GetVortoValue<IPublishedContent>(DataItemProperty) : that.GetVortoValue<IPublishedContent>(DataItemProperty, fallbackCultureName: "en-US"));
            
            return defaultDataItem;
        }
    }
}
