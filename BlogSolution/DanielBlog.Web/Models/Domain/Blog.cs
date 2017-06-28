using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DanielBlog.Web.Models.Domain
{
    public class Blog
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string AuthorGuid { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }


        public class Comment
        {
            public int ID { get; set; }
            public int BlogID { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public string UserName { get; set; }
            public DateTime DateCreated { get; set; }
            public DateTime DateModified { get; set; }

            public class Reply : Comment
            {
                public int ParentCommentID { get; set; }
            }
        }
    }
}