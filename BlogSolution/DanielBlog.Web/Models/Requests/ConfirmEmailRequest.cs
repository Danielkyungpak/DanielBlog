using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DanielBlog.Web.Models.Requests
{
    public class ConfirmEmailRequest
    {
        public string Recipient { get; set; }
        public string CallBack { get; set; }
        public string RecipientUserName { get; set; }
        public string Code { get; set; }

    }
}