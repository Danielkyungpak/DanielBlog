using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DanielBlog.Web.Models.Shared
{
    public class ItemResponse<T>
    {
        public T Item { get; set; }
    }
}