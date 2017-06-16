using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DanielBlog.Web.Models.View
{
    public class ItemViewModel<T>
    {
        public T Item { get; set; }
    }
}