using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DanielBlog.Web.Models.Requests
{
    public class ContactMeEmailRequest
    {
        public string Sender { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }

    }
}