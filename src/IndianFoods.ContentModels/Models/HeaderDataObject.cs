using Umbraco.Core.Models;
using Umbraco.ModelsBuilder;
using Umbraco.Web;
using Our.Umbraco.Vorto.Extensions;

namespace IndianFoods.ContentModels
{
    public partial class HeaderDataObject
    {
        public const string DataItemProperty = "headerData";       

        internal static HeaderDataObject DataItem(IHeader that)
        {
            var defaultDataItem = new HeaderDataObject(that.HasVortoValue(DataItemProperty) ? that.GetVortoValue<IPublishedContent>(DataItemProperty) : that.GetVortoValue<IPublishedContent>(DataItemProperty, fallbackCultureName: "en-US"));
            
            return defaultDataItem;
        }
    }
}
