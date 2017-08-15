using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DanielBlog.Web.Controllers
{
    public class BlogController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Manage()
        {
            return View();
        }
        public ActionResult Blog()
        {
            return View();
        }
    }
}