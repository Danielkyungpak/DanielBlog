using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DanielBlog.Web.Models.Requests
{
    public class UserLoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}