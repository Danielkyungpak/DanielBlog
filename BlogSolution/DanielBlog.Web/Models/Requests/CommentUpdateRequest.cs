using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DanielBlog.Web.Models.Requests
{
    public class CommentUpdateRequest
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int? ParentCommentId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}