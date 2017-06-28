using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DanielBlog.Web.Controllers
{
    public class PokerController : Controller
    {
        // GET: Poker
        public ActionResult Play()
        {
            return View();
        }
    }
}