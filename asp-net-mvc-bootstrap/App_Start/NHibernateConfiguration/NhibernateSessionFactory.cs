using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp_net_mvc_bootstrap.App_Start.NHibernateConfiguration
{
    public class NhibernateSessionFactory
    {
        public ISessionFactory GetSessionFactory()
        {
            ISessionFactory fluentConfiguration = Fluently.Configure()
                                                   .Database(MySQLConfiguration.Standard.ConnectionString(c => c.FromConnectionStringWithKey("DefaultConnection")))
                                                   .Mappings(m => m.FluentMappings.AddFromAssemblyOf<asp_net_mvc_bootstrap.Models.Concrete.Item>())
                                                   .ExposeConfiguration(BuidSchema)
                                                   .BuildSessionFactory();

            return fluentConfiguration;
        }

        private static void BuidSchema(Configuration config)
        {
            //create and update automatically
            new SchemaUpdate(config).Execute(false, true);
        }
    }
}