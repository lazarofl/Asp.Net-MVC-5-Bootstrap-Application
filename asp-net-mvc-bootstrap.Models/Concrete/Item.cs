using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asp_net_mvc_bootstrap.Models.Concrete
{
    public class Item : IEntity<int>
    {
        public virtual string Name { get; set; }
        public virtual bool Done { get; set; }
    }
}
