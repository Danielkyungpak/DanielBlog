using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DanielBlog.Web.Models.Domain
{
    public class PersonAddRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}