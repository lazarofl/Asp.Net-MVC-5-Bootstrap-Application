using asp_net_mvc_bootstrap.Models.Concrete;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp_net_mvc_bootstrap.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ISession session)
            : base(session)
        {

        }

        public ActionResult Index()
        {
            IList<Item> itens;
            using (var transaction = session.BeginTransaction())
            {
                itens = session.Query<Item>().ToList();
                transaction.Commit();
            }

            return View(itens);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}