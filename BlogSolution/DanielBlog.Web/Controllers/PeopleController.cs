using DanielBlog.Web.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DanielBlog.Web.Controllers
{
    [RoutePrefix("People")]
    public class PeopleController : Controller
    {
        // GET: First
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }
        [Route("Create")]
        [Route("{id:int?}/edit")]
        public ActionResult Manage(int? id = null)
        {
            ItemViewModel<int?> model = new ItemViewModel<int?>();
            model.Item = id;
            return View(model);
        }
    }
}