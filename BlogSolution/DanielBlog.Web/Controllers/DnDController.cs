using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DanielBlog.Web.Controllers
{
    public class DnDController : Controller
    {
        // GET: DnD
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CharacterCreate()
        {
            return View();
        }
    }
}