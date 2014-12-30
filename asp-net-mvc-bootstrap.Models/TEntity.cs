using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asp_net_mvc_bootstrap.Models
{
    public abstract class TEntity<T>
    {
        public virtual T Id { get; private set; }
    }
}
