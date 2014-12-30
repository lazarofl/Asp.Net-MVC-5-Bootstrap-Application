using NHibernate;
using Ninject.Activation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp_net_mvc_bootstrap.App_Start.NHibernateConfiguration
{
    public class NhibernateSessionFactoryProvider : Provider<ISessionFactory>
    {
        protected override ISessionFactory CreateInstance(IContext context)
        {
            var sessionFactory = new NhibernateSessionFactory();
            return sessionFactory.GetSessionFactory();
        }
    }
}