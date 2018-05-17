using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using toptenV2.Services;

namespace toptenV2.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Confirm your email",
                $"Thank you for joining #1TopTen! Please confirm your account by clicking <a href='{HtmlEncoder.Default.Encode(link)}'>here</a>.");
        }
    }
}
