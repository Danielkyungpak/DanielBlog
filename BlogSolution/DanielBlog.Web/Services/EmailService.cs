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
            var from = new EmailAddress("daniel.donotreply@gmail.com", "Daniel Pak");
            var subject = "Please Confirm Your Email";
            var to = new EmailAddress(payload.Recipient, payload.RecipientUserName);
            var plainTextContent = payload.CallBack;
            var htmlContent = "<a class='button-a' style='color:#000; background: #fff; border: 15px solid #fff; font-family: sans-serif; font-size: 13px; line-height: 1.1; text-align: center; text-decoration: none; display: block; border-radius: 3px; font-weight: bold' href='" + payload.CallBack + "'>" + "Click here to confirm registration </a>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        // Sends a Contact Email
        public static async Task ContactMe(ContactMeEmailRequest payload)
        {

            var apiKey = ConfigurationManager.AppSettings["SendGridAPIKey"].ToString();
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(payload.Sender, payload.Name);
            var subject = "Someone has messaged you from your website!";
            var to = new EmailAddress("danielkyungpak@gmail.com", "Example User");
            var plainTextContent = payload.Message;
            var htmlContent = "<p>" + payload.Message + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);


        }
    }
}