using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianFoods.ContentModels.Navigation
{
    public class MenuItem : BaseModel
    {
        public bool Active { get; set; }
        public IExtendedNavigation SubMenu { get; set; }
    }
}
