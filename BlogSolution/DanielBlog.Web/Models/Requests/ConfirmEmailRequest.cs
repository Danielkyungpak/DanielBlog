using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DanielBlog.Web.Models.Requests
{
    public class ConfirmEmailRequest
    {
        public ConfirmEmailRequest(EmailAddress recipient, string code, string callback)
        {
            this.Recipient = recipient;
            this.Code = code;
            this.Sender = new EmailAddress("daniel.donotreply@gmail.com", "Daniel");
            this.Subject = "Confirm your registration.";
            this.CallbackUrl = callback;
            var request = HttpContext.Current.Request;
            var address = string.Format("{0}://{1}", request.Url.Scheme, request.Url.Authority);
            this.Body = "<a class='button-a' style='color:#000; background: #fff; border: 15px solid #fff; font-family: sans-serif; font-size: 13px; line-height: 1.1; text-align: center; text-decoration: none; display: block; border-radius: 3px; font-weight: bold' href='" + address + callback + "'>" + "Click here to confirm registration </a>";

        }

        public EmailAddress Recipient { get; private set; }
        public string Code { get; private set; }
        public EmailAddress Sender { get; private set; }
        public string Subject { get; private set; }
        public string CallbackUrl { get; private set; }
        public string Body { get; private set; }

    }
}