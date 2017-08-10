using System.Collections.Generic;
using System.Linq;
using Umbraco.Web;
using System.Web;
using Umbraco.Core.Models;

namespace IndianFoods.ContentModels
{
	public partial interface IFooter
	{
		IEnumerable<string> HeaderItems { get; }
        FooterDataObject FooterDataObject { set; get; }
    }

	public partial class Footer
	{
        public FooterDataObject FooterDataObject { set; get; }
        public string FooterHeader
		{
			// cache
			get { return GetHeader(this); }
		}

        private static FooterDataObject CachedData(IFooter that)
        {
            return that.FooterDataObject = that.FooterDataObject == null ? FooterDataObject.DataItem(that) : that.FooterDataObject;
        }

        internal static string GetHeader(IFooter that)
		{
			return CachedData(that).FooterData;
	   }

		internal static IEnumerable<string> GetHeaderItems(IFooter that)
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
