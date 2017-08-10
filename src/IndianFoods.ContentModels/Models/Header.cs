using System.Collections.Generic;
using System.Linq;
using Umbraco.Web;
using System.Web;
using Umbraco.Core.Models;
using IndianFoods.ContentModels;

namespace IndianFoods.ContentModels
{
    public partial interface IHeader
    {
        IEnumerable<string> HeaderItems { get; }

        HeaderDataObject HeaderDataObject { set; get; }
    }

    public partial class Header
    {
        public HeaderDataObject HeaderDataObject { set; get; }
        
        public string TopHeader
        {
            // cache
            get { return GetHeader(this); }
        }

        private static HeaderDataObject CachedData(IHeader that)
        {
            return that.HeaderDataObject = that.HeaderDataObject == null ? HeaderDataObject.DataItem(that) : that.HeaderDataObject;
        }

        internal static string GetHeader(IHeader that)
        {
            return CachedData(that).HeaderData;
        }

        internal static IEnumerable<string> GetHeaderItems(IHeader that)
        {
            var header = GetHeader(that);

            if (!string.IsNullOrWhiteSpace(header))
            {
                return header.Split('\n').ToList();
            }
            return new List<string>();
        }
        
        public IEnumerable<string> HeaderItems
        {
            get
            {
                return GetHeaderItems(this);
            }
        }
    }
}
