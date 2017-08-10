using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianFoods.ContentModels.Navigation
{
    class ExtendedNavigation : IExtendedNavigation
    {
        private IEnumerable<MenuItem> _subItems;

        public IEnumerable<MenuItem> SubItems => _subItems;
    }
    
}
