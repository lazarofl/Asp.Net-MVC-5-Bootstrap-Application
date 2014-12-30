using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp_net_mvc_bootstrap.Infrastructure.NHibernateConfiguration
{
    public class InMemoryNHibernateSessionFactory
    {
        public ISessionFactory GetSessionFactory()
        {
            ISessionFactory fluentConfiguration = Fluently.Configure()
                                                   .Database(SQLiteConfiguration.Standard.InMemory)
                                                   .Mappings(m => m.FluentMappings.AddFromAssemblyOf<asp_net_mvc_bootstrap.Models.Concrete.Item>())
                                                   .ExposeConfiguration(BuidSchema)
                                                   .BuildSessionFactory();

            return fluentConfiguration;
        }

        private static void BuidSchema(Configuration config)
        {
            new SchemaExport(config).Create(false, true);
        }
    }
}