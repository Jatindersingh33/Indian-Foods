using IndianFoods.ContentModels;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.ModelsBuilder;

namespace IndianFoods.ContentModels
{
    public partial class HomePage
    {

        #region Header
       
        public HeaderDataObject HeaderDataObject { set; get; }
        public FooterDataObject FooterDataObject { set; get; }

        IEnumerable<string> IHeader.HeaderItems
        {
            get { return Header.GetHeaderItems(this); }
        }
        #endregion

        #region Footer

        IEnumerable<string> IFooter.HeaderItems
        {
            get { return Footer.GetHeaderItems(this); }
        }
        #endregion

    }
}
