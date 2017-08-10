using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianFoods.ContentModels.Navigation
{
    public abstract class BaseModel
    {
        public bool Visible { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
