﻿using asp_net_mvc_bootstrap.Infrastructure.UnitOfWork;
using asp_net_mvc_bootstrap.Models.Concrete;
using Facebook;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp_net_mvc_bootstrap.Controllers
{
    public class HomeController : Controller
    {
        IUnitOfWork unitOfWork;

        public HomeController(IUnitOfWork _work)
        {
            this.unitOfWork = _work;
        }

        public ActionResult Index()
        {
            IList<Item> itens;

            using (unitOfWork)
            {
                var itensRepository = unitOfWork.GetRepository<Item>();

                itens = itensRepository.All().ToList();

                unitOfWork.Commit();
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

        public ActionResult UserInfo(string accessToken)
        {
            var client = new FacebookClient(accessToken);
            dynamic result = client.Get("me", new { fields = "name,id" });

            return Json(new
            {
                id = result.id,
                name = result.name,
            });
        }
    }
}