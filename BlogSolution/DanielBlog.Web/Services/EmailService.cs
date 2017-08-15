using DanielBlog.Web.Models.Requests;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DanielBlog.Web.Services
{
    public class EmailService
    {
        // Sends a Confirmation Email
        public static async Task SendConfirmationEmail(ConfirmEmailRequest payload)
        {
            var apiKey = ConfigurationManager.AppSettings["SendGridAPIKey"].ToString();
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage();
            msg.SetFrom(new EmailAddress(payload.Sender.Email, payload.Sender.Name));
            msg.AddTo(payload.Recipient);
            //msg.AddSubstitution("-confirmlink-", payload.Body);
            //msg.SetTemplateId("ebd03b55-f62d-461f-9881-f046828996aa");
            var response = await client.SendEmailAsync(msg);


        }
    }
}