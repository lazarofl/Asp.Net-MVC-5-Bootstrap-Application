using NHibernate;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp_net_mvc_bootstrap.Controllers
{
    public class BaseController : Controller
    {
        protected ISession session { get; private set; }

        public BaseController(ISession _session)
        {
            this.session = _session;
        }

    }
}