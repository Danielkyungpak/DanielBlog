using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DanielBlog.Web.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult ContactMe()
        {
            return View();
        }
    }
}