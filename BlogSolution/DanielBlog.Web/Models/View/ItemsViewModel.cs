using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DanielBlog.Web.Models.View
{
    public class ItemsViewModel<T>
    {
        public List<T> Items { get; set; }
    }
}