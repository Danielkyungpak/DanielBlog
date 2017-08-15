using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DanielBlog.Web.Models.Requests
{
    public class BlogAddRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string AuthorGuid { get; set; }

    }
}