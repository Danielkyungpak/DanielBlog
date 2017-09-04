using DanielBlog.Web.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DanielBlog.Web.Controllers
{
    [RoutePrefix("DnD")]
    public class DnDController : Controller
    {
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }
        [Route("CharacterCreate")]
        public ActionResult CharacterCreate()
        {
            return View();
        }
        [Route("Characters")]
        public ActionResult Characters()
        {
            return View();
        }
        [Route("Character/{id:int?}")]
        public ActionResult Character(int id)
        {
            ItemViewModel<int> model = new ItemViewModel<int>();
            model.Item = id;
            return View(model);
        }
    }
}