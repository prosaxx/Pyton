using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Loja.WEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cliente()
        {
            return View();
        }

        public ActionResult Salvar(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Entre em contato comigo";

            return View();
        }
    }
}