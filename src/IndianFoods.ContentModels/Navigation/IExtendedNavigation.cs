using System.Collections.Generic;

namespace IndianFoods.ContentModels.Navigation
{
    public interface IExtendedNavigation
    {
        IEnumerable<MenuItem> SubItems { get; }
    }
}
