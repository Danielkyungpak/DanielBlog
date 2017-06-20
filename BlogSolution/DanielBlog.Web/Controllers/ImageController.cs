using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DanielBlog.Web.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult Upload()
        {
            return View();
        }
    }
}