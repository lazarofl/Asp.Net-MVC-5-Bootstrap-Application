using asp_net_mvc_bootstrap.Models.Concrete;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asp_net_mvc_bootstrap.Models.Mapping
{
    public class ItemMap : ClassMap<Item>
    {
        public ItemMap()
        {
            Table("Item");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Not.Nullable().Length(100);
            Map(x => x.Done).Not.Nullable().Default("0");
        }
    }
}
